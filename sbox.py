from collections import OrderedDict
from functools import reduce
from operator import xor
from copy import deepcopy
from pathlib import Path
import pylatex

from helpers import (
    Boole,
    AttrFree,
    truth_table_from_list,
    generate_tuples,
    _get_latex_doc
)

class SBox:
    """
    S-kutusunu temsil eden sınıf. S-kutuları birden fazla Boole fonksiyonunun
    birleşmesiyle oluşur.
    """

    def __init__(self, functions:list):
        if not functions:
            raise Exception("0 fonksiyonlu bir SBox oluşturulamaz.")

        if not all(type(f) == Boole for f in functions):
            raise Exception("SBox koordinat fonksiyonlarının hepsi Boole "+
                "fonksiyonu olmalı.")

        if len(set(f.n for f in functions)) != 1:
            raise Exception("SBox koordinat fonksiyonlarının dereceleri aynı "+
                "olmalı.")

        self._coordinate_funcs = deepcopy(functions)

    def __call__(self, *args):
        return tuple(f(*args) for f in self._coordinate_funcs)

    def __getitem__(self, i):
        return deepcopy(self._coordinate_funcs[i])

    @property
    def n(self):
        "S-kutusunun girdi boyutu."
        # Hepsi aynı olduğundan ilkini almak yeterli.
        return self._coordinate_funcs[0].n

    @property
    def m(self):
        "S-kutusunun çıktı boyutu"
        return len(self._coordinate_funcs)

    @property
    def coordinate_funcs(self):
        return deepcopy(self._coordinate_funcs)

    def _component_func(self, *coeff):
        """
        Katsayılara uygun komponent fonksiyonu verir.
        ```
        self._component_func(1,1,0) : f1 (xor) f2
        self._component_func(1,0,1) : f1 (xor) f3
        self._component_func(1,1,1) : f1 (xor) f2 (xor) f3
        ```
        """

        return lambda x: reduce(
            xor,
            [c * self[num](*x) for num, c in enumerate(coeff)]
        )

    def component_funcs(self):
        """
        S-kutusunun tüm komponent fonksiyonlarını döndürür. Sadece f1, sadece
        f2, sadece f3 ... gibi tek başına fonksiyonlar dahildir. 0 fonksiyonu
        dahil değildir. `OrderedDict` döndürür.
        ```
        self.component_funcs()[1,1,0] : f1 (xor) f2
        self.component_funcs()[1,0,1] : f1 (xor) f3
        self.component_funcs()[1,1,1] : f1 (xor) f2 (xor) f3
        ```
        """

        tuples = generate_tuples(len(self._coordinate_funcs), reverse=True)
        next(tuples)
        sorted_tuples = sorted(tuples, key=sum)

        return OrderedDict(
            (t, Boole(self._component_func(*t))) for t in sorted_tuples
        )

    def component_truth_table(self):
        "Komponent fonksiyonları dahil, doğruluk tablosu."

        component_funcs = self.component_funcs().values()
        return {
            t: [f(*t) for f in component_funcs]
            for t in generate_tuples(self.n)
        }

    def nonlinearity(self):
        """
        S-kutusunun doğrusal olmama değeri, komponent fonksiyonlarının
        doğrusal olmama değerlerinin en küçüğüdür.

        AttrFree.int döndürür, eklenen attr'lar:
        - `.values`
        """

        values = [f.nonlinearity() for f in self.component_funcs().values()]
        result = AttrFree.int(min(values))
        result.values = values
        return result

    def absolute_indicator(self):
        """
        S-kutusunun mutlak göstergesi, komponent fonksiyonlarının mutlak
        göstergelerinin en büyüğüdür.

        AttrFree.int döndürür, eklenen attr'lar:
        - `.values`
        """

        values = [
            f.absolute_indicator() for f in self.component_funcs().values()
        ]
        result = AttrFree.int(max(values))
        result.values = values
        return result

    def algebraic_degree(self):
        """
        S-kutusunun cebirsel derecesi, koordinat fonksiyonlarının cebirsel
        derecelerinin en büyüğüdür.

        AttrFree.int döndürür, eklenen attr'lar:
        - `.values`
        """

        # koordinat fonksiyonlarına bakmamız yeterli
        values = [f.algebraic_degree() for f in self.coordinate_funcs]
        result = AttrFree.int(max(values))
        # tabloya çizdirmek için komponent fonksiyonları da alalım
        result.values = [
            f.algebraic_degree() for f in self.component_funcs().values()
        ]
        return result


def header_from_tuple(t:tuple):
    return r" \oplus ".join(f"f_{i+1}(x)" for i, val in enumerate(t) if val)

def main(sbox:SBox, pdf_path=Path.cwd() / __file__[:-3]):
    component_funcs = sbox.component_funcs()
    truth_table = sbox.component_truth_table()
    nonlinearity = sbox.nonlinearity()
    absolute_indicator = sbox.absolute_indicator()
    algebraic_degree = sbox.algebraic_degree()

    doc = _get_latex_doc(margin="1cm")

    doc.append(pylatex.NoEscape(r"""
        S-kutuları, birden fazla Boole fonksiyonunun ($f_1, f_2, ...$) bir
        araya getirilmesi ile oluşur. $S: F_2^n \rightarrow F_2^m$ olacak
        şekilde $n$ biti $m$ bite dönüştürürler. Bu Boole fonksiyonlarına
        S-kutusunun \textbf{koordinat fonksiyonları} denir.
    """))

    doc.append(pylatex.NoEscape(r"""
        Koordinat fonksiyonlarının herhangi bir lineer birleşimi S-kutusunun
        \textbf{komponent fonksiyonu} olarak isimlendirilir. Komponent
        fonksiyonları bir Boole fonksiyondur.
    """))

    doc.append(pylatex.NoEscape(r"""
        S-kutusunun doğrusal olmama değeri ($NL_f$), \underline{komponent
        fonksiyonlarının} doğrusal olmama değerlerinin \textbf{en küçüğüdür}.
    """))

    doc.append(pylatex.NoEscape(r"""
        S-kutusunun mutlak gösterge değeri ($\Delta_f$), \underline{komponent
        fonksiyonlarının} mutlak gösterge değerlerinin \textbf{en büyüğüdür}.
    """))

    doc.append(pylatex.NoEscape(r"""
        S-kutusunun cebirsel derecesi ($d_f$), \underline{koordinat
        fonksiyonlarının} cebirsel derecelerinin \textbf{en büyüğüdür}.
    """))

    doc.append(pylatex.NoEscape(r"""
        Elimizdeki S-kutusunun komponent fonksiyonlarının doğruluk tablosu, ve
        bu fonksiyonların gerekli değerleri şöyledir:
    """))

    table_spec = "|c|" + ("c|" * len(component_funcs))
    with doc.create(pylatex.Tabular(table_spec)) as table:
        table.add_hline()

        first = [pylatex.Math(inline=True, escape=False, data=r"x")]
        for key in component_funcs.keys():
            first.append(pylatex.Math(
                inline=True,
                escape=False,
                data=header_from_tuple(key)
            ))

        table.add_row(first)
        table.add_hline()

        for t in generate_tuples(sbox.n):
            table.add_row([t] + truth_table[t])
            table.add_hline()
        table.add_hline()

        table.add_row(
            [pylatex.Math(inline=True, escape=False, data=r"NL_f")] +
            nonlinearity.values
        )
        table.add_hline()

        table.add_row(
            [pylatex.Math(inline=True, escape=False, data=r"\Delta_f")] +
            absolute_indicator.values
        )
        table.add_hline()

        table.add_row(
            [pylatex.Math(inline=True, escape=False, data=r"d_f")] +
            [
                v if i < len(sbox.coordinate_funcs) else f"({v})"
                for i, v in enumerate(algebraic_degree.values)
            ]
        )
        table.add_hline()

    doc.append(pylatex.NoEscape(f"""
        Buna göre S-kutusunun doğrusal olmama değeri $NL_f = {nonlinearity}$,
        mutlak gösterge değeri $\\Delta_f = {absolute_indicator}$, cebirsel
        derecesi $d_f = {algebraic_degree}$ olur.
    """))

    doc.generate_pdf(pdf_path)

if __name__ == "__main__":
    # TODO: S-kutularının tanımı daha kolay olmalı.
    s = SBox([
        Boole(truth_table_from_list([0,1,1,0,0,0,1,1])),
        Boole(truth_table_from_list([0,1,0,1,0,1,0,1])),
        Boole(truth_table_from_list([0,0,0,0,1,1,1,1])),
    ])

    main(s)
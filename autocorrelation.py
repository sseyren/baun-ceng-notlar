import numpy as np
import pylatex
from pathlib import Path

from helpers import generate_tuples, AttrFree

class Boole:
    """
    Boole fonksiyonlarını temsil eden sınıf. Bir boole fonksiyonunu doğruluk
    tablosuyla veya doğrudan bir fonksiyon ile oluşturulabilir.

    Doğruluk tablosuyla oluşturmak için yapıcı metoda `dict` objesi verilir:

    f = Boole({
        (0,0): 0,
        (0,1): 0,
        (1,0): 0,
        (1,1): 1,
    })

    Fonksiyon ile oluşturmak için `tuple` girdi alan herhangi çağrılabilir
    obje yeterli:

    f = Boole(lambda x: x[0] * x[1])

    Oluşturulan Boole fonksiyonu kullanıma hazır, şu şekilde işletilir:

    f(0, 1)

    """

    def __init__(self, dict_or_func):
        self._truth_table = None
        self._method = None
        # Boole fonksiyonunun değişken sayısı
        self.n = 0

        if type(dict_or_func) == dict:
            key_lens = set(map(len, dict_or_func.keys()))
            if len(key_lens) > 1:
                raise Exception("Dict'te sorun var")

            self._truth_table = dict_or_func.copy()
            self.n = key_lens.pop()
        elif callable(dict_or_func):
            self._method = dict_or_func

            n = 0
            while True:
                try:
                    self._method(tuple(0 for i in range(n)))
                except IndexError:
                    n += 1
                else:
                    self.n = n
                    break

    def __call__(self, *args):
        if self._method:
            return self._method(args)
        elif self._truth_table:
            return self._truth_table[args]
        else:
            raise NotImplementedError("Boole fonksiyonu için doğruluk tablosu "+
                "veya fonksiyon girilmedi")

    def autocorr_func(self):
        def func(*d):
            s = 0
            tabular = []

            for x in generate_tuples(self.n):
                l = pow(-1, self(*x))
                x_xor_d = tuple((np.array(x) ^ np.array(d)).tolist())
                r = pow(-1, self(*x_xor_d))
                s += l * r
                tabular.append(
                    [x, self(*x), x_xor_d, self(*x_xor_d), l, r, l*r])

            s = AttrFree.int(s)
            s.repr = tabular
            return s

        return func

def main(f:Boole, pdf_path=Path.cwd() / __file__[:-3]):
    autocorr_func = f.autocorr_func()

    doc = pylatex.Document(
        document_options=["a4paper","12pt"],
        geometry_options={"margin": "1in"},
    )
    doc.content_separator = "%\n\n"
    doc.preamble.append(
        pylatex.UnsafeCommand("setlength", r"\parskip", extra_arguments="1em")
    )

    doc.append(pylatex.NoEscape(
        r"""$F_2 = \{0, 1\}$ ve $F_2^n$, $F_2$ kümesinin kendisiyle $n$ defa
        kartezyen çarpımı olsun. """
        +
        f"""$n = {f.n}$ değişkenli $f(x)$ Boole fonksiyonunun otokorelasyon fonksiyonu
        $r_f(d)$ şöyledir:"""
    ))
    doc.append(pylatex.Math(
        escape=False,
        data=r"r_f(d) = \sum_{x \in F_2^"+str(f.n)+r"} (-1)^{f(x)}(-1)^{f(x \oplus d)}"
    ))

    doc.append(pylatex.utils.bold("Hesaplamalar:"))

    for d in generate_tuples(f.n):
        result = autocorr_func(*d)

        doc.append(f"d = {d} için:")
        with doc.create(pylatex.Tabular("|c|c|c|c|c|c|c|")) as table:
            table.add_hline()
            table.add_row([
                pylatex.Math(inline=True, escape=False, data=r"x"),
                pylatex.Math(inline=True, escape=False, data=r"f(x)"),
                pylatex.Math(inline=True, escape=False, data=r"x \oplus d"),
                pylatex.Math(inline=True, escape=False, data=r"f(x \oplus d)"),
                pylatex.Math(inline=True, escape=False, data=r"(-1)^{f(x)}"),
                pylatex.Math(inline=True, escape=False, data=r"(-1)^{f(x \oplus d)}"),
                pylatex.Math(inline=True, escape=False, data=r"(-1)^{f(x)}(-1)^{f(x \oplus d)}"),
            ])
            table.add_hline()
            for row in result.repr:
                table.add_row(row)
                table.add_hline()

        doc.append(pylatex.NoEscape(
            f"$r_f(d)$ = $r_f{d}$ = {result}"
        ))

    doc.generate_pdf(pdf_path)

if __name__ == "__main__":
    f = Boole(lambda x: ((x[0] * x[2]) + x[1]) % 2)

    main(f)
from pathlib import Path
import pylatex

from helpers import (
    Boole,
    truth_table_from_list,
    _get_latex_doc
)

def main(f:Boole, pdf_path=Path.cwd() / __file__[:-3]):
    degree = f.algebraic_degree()

    doc = _get_latex_doc()

    doc.append(pylatex.NoEscape(
        r"""\textbf{Cebirsel derece}, bir boole fonksiyonunun cebirsel
        ifadesinde, çarpım halinde kullanılan en yüksek değişken sayısıdır.
        Cebirsel derecesi 1 olan boole fonksiyonlarına \emph{doğrusal} boole
        fonksiyonları denir."""
    ))

    doc.append(pylatex.NoEscape(
        """$f$ fonksiyonunun doğruluk tablosundan cebirsel ifadesini elde
        edelim. Fonksiyonun doğruluk tablosu:"""
    ))

    with doc.create(pylatex.Tabular("|c|c|")) as table:
        table.add_hline()
        table.add_row([
            pylatex.Math(inline=True, escape=False, data=r"x"),
            pylatex.Math(inline=True, escape=False, data=r"f(x)"),
        ])
        table.add_hline()
        for row in f.truth_table.items():
            table.add_row(row)
            table.add_hline()

    str_repr = r" \oplus ".join(
        "[ "+
            " ".join("( "+
                r" \oplus ".join(str(term) for term in dual)
            +" )" for dual in part)
        +" ]" for part in degree.history[0]
    )
    doc.append(pylatex.Math(inline=True, escape=False,
        data=f"f(x) = {str_repr}"))

    str_repr = r" \oplus ".join(
        "( "+
            r" \oplus ".join(str(term) for term in part)
        +" )" for part in degree.history[1]
    )
    doc.append(pylatex.Math(inline=True, escape=False,
        data=f"f(x) = {str_repr}"))

    str_repr = r" \oplus ".join(str(term) for term in degree.history[2])
    doc.append(pylatex.Math(inline=True, escape=False,
        data=f"f(x) = {str_repr}"))

    doc.append(pylatex.NoEscape(
        f"""Çarpım halinde bulunan en yüksek değişken sayısı {degree}
        olduğundan, fonksiyonun cebirsel derecesi {degree} olacaktır."""
    ))

    doc.generate_pdf(pdf_path)

if __name__ == "__main__":
    f = Boole(truth_table_from_list([0,0,1,1,0,1,1,0]))

    main(f)
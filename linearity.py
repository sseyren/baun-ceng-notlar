from pathlib import Path
import pylatex

from helpers import (
    Boole,
    generate_tuples,
    truth_table_from_list,
    _get_latex_doc
)

def main(f:Boole, pdf_path=Path.cwd() / __file__[:-3]):
    val = f.nonlinearity()

    doc = _get_latex_doc()

    doc.append(pylatex.NoEscape(
        f"""$f$ boole fonksiyonunun doğrusal olmama değerini hesaplayabilmek
        için {f.n} ($f$'in derecesidir) elemanlı tüm lineer fonksiyonlar
        bulunur. Ardından bu fonksiyonlar ile $f$ fonksiyonu arasındaki uzaklık
        hamming uzaklığı ile ölçülür."""
    ))
    doc.append(pylatex.NoEscape(
        """Hamming uzaklığı iki fonksiyonun doğruluk tablosunun birbirlerinden
        farklı elemanlarının sayısının toplamıdır."""
    ))

    doc.append(pylatex.NoEscape(
        r"Kullanılacak tüm doğrusal fonksiyonlar:"
    ))
    with doc.create(pylatex.Itemize()) as itemize:
        for i, lin_func in enumerate(val.functions, 1):
            itemize.add_item(
                pylatex.Math(inline=True, escape=False,
                    data=f"f_{i} = {lin_func.repr}"))

    doc.append(pylatex.NoEscape(
        r"$f$ fonksiyonunun doğruluk tablosu:"
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

    def print_distance_matrix(X, X_d):
        table_spec = "|" + "c|" * (len(X[0])+1)
        with doc.create(pylatex.Tabular(table_spec)) as table:
            table.add_hline()
            table.add_row(
                [pylatex.Math(inline=True, escape=False, data=r"x")] +
                [pylatex.Math(inline=True, escape=False, data=f"f_{i}(x)")
                    for i in range(1, len(val.functions) + 1)]
            )
            table.add_hline()
            for t, row in zip(generate_tuples(f.n), X):
                table.add_row([t] + row)
                table.add_hline()
            table.add_row(["Uzaklık"] + X_d)
            table.add_hline()

    doc.append(pylatex.NoEscape(
        r"$f$ fonksiyonunun doğrusal fonksiyonlara uzaklığı:"
    ))
    print_distance_matrix(val.X, val.X_d)
    doc.append(pylatex.NoEscape(
        r"$f$ fonksiyonunun doğrusal fonksiyonların tümleyenlerine uzaklığı:"
    ))
    print_distance_matrix(val.inv_X, val.inv_X_d)

    doc.append(pylatex.NoEscape(
        f"""Bu uzaklıklar içinden en küçüğü {val} olduğundan $f$ fonksiyonunun
        doğrusal olmama değeri {val} olur."""
    ))

    doc.generate_pdf(pdf_path)

if __name__ == "__main__":
    f = Boole(truth_table_from_list([0,0,1,0,1,1,0,1]))

    main(f)
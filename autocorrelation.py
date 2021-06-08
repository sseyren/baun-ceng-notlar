import pylatex
from pathlib import Path

from helpers import generate_tuples, Boole

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
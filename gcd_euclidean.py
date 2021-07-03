import pylatex
from pathlib import Path

from helpers import _get_latex_doc

def _components_of_gcd(a:int, b:int, gcd:int):
    a //= gcd
    b //= gcd

    x, y = 1, -1
    while abs(a*x + b*y) != 1:
        y -= 1
        if a*x + b*y < -1:
            x += 1
            y = -1

    if a*x + b*y < 0:
        x, y = -x, -y

    return x, y

def main(a:int, b:int, pdf_path=Path.cwd() / __file__[:-3]):
    if a < b:
        temp = a
        a = b
        b = temp

    doc = _get_latex_doc()
    doc.append(pylatex.NoEscape(
        r"\textbf{Soru:} " + f"$ebob({a}, {b})$ kaçtır?"
    ))

    doc.append(pylatex.NoEscape(f"""
        Soruda öklid algoritması kullanılabilir. Kısaca şöyle çalışır;
        $ebob(a, b)$ ve $a > b$ için $a$, $b$'ye bölünür. Bu bölümden kalan sayı
        $r$ olsun. Ardından $b$, $r$'ye bölünür. Ardından $r$, bir önceki
        bölümden kalan sayıya bölünür. Bu adımlar kalan 0'a ulaşana kadar
        tekrarlanır. Son adımda bölen, $ebob$'dur.
    """))

    doc.append(pylatex.NoEscape(r"""
        ($\textrm{bölünen} = \textrm{bölüm} * \textrm{bölen} + \textrm{kalan}$)
    """))

    x, y = a, b  # geçici değişkenler
    while y != 0:
        q = x // y
        r = x % y
        doc.append(pylatex.NoEscape(f"${x} = {q} \\cdot {y} + {r}$"))
        x = y
        y = r
    gcd = x

    doc.append(pylatex.NoEscape(f"Sonuç olarak $ebob({a}, {b}) = {gcd}$ olur."))

    doc.append(pylatex.NoEscape(
        r"\textbf{Soru:} " +
        f"$ebob({a}, {b}) = {a}x + {b}y$ ifadesinde $x$ ve $y$ sayıları ne olur?"
    ))

    x, y = _components_of_gcd(a, b, gcd)

    doc.append(pylatex.NoEscape(f"""
        Öklid adımları tersten takip edilerek bu değerler elde edilebilir:
    """))

    doc.append(pylatex.NoEscape(f"""
        $ebob({a}, {b}) = {gcd} = {a} \\cdot {x} + {b} \\cdot {y}$ olduğundan,
        $x = {x}$ ve $y = {y}$ olacaktır.
    """))

    if gcd == 1:
        doc.append(pylatex.NoEscape(
            r"\textbf{Soru:} " +
            f"${b}$ sayısının $mod$ {a} için aritmetik tersi nedir?"
        ))

        doc.append(pylatex.NoEscape(r"""
            $a \ne 0$ herhangi bir tamsayı olmak üzere, eğer
            $a \cdot a^* \equiv 1 \, mod \, n$ denkliğini sağlayan bir $a^*$
            tamsayısı var ise bu $a^*$ sayısına $a$’nın $mod \, n$’ye göre
            aritmetik tersi denir. Eğer $ebob(a, n) = 1$ ise (yani $a$ ve $n$
            aralarında asal ise) $a$’nın $mod \, n$’ye göre aritmetik tersi
            \underline{vardır}.
        """))

        doc.append(pylatex.NoEscape(f"""
            ${gcd} = {a} \\cdot {x} + {b} \\cdot {y}$ olduğundan
            ${b} \\cdot {y} \\equiv 1 \\, mod \\, {a}$ yazılabilir.
        """))

        doc.append(pylatex.NoEscape(f"""
            Böylece, ${b}$ sayısının $mod$ {a} için aritmetik tersi ${y}$
            bulunur.
        """))

    doc.generate_pdf(pdf_path)

if __name__ == "__main__":
    main(513, 7)
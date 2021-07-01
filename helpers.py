from functools import reduce
from operator import xor
from itertools import product
from copy import deepcopy
import math
import numpy as np
import pylatex

def generate_tuples(n=2, reverse=False):
    """
    Sıralı tuple'lar oluşturur. Örneğin `n=2` için
    `(0,0) (0,1) (1,0) (1,1)` gibi tuple'lar oluşturur.

    Generator döndürür.
    """

    counter = 0
    for _ in range(pow(2, n)):
        bitstr = format(counter, f"0{n}b")
        if reverse:
            bitstr = bitstr[::-1]
        yield tuple(int(b) for b in bitstr)
        counter += 1

def linear_function(*coeff):
    """
    Tuple katsayıları alır ve lineer fonksiyonu döndürür. Dönen fonksiyonların
    tuple'daki eleman sayısı kadar girdi alması gerekir.
    """
    f = lambda *x: reduce(xor, [x[num] * c for num, c in enumerate(coeff)])

    # latex representation
    f.repr = r" \oplus ".join(f"{c}x_{num}" for num, c in enumerate(coeff, 1))
    return f

def hamming_dist(x:list, y:list):
    if len(x) != len(y):
        raise Exception("İki listenin uzunluğu aynı değil.")

    counter = 0
    for i, j in zip(x, y):
        if i != j:
            counter += 1

    return counter

def bool_inverse(x:list):
    """
    Listenin içindeki 0'ı 1, 1'i 0 yapar. Recursivedir. Listenin içindeki de
    mutlaka liste olmalıdır.
    """
    return [bool_inverse(i) if type(i) == list else int(not bool(i)) for i in x]

def truth_table_from_list(x:list):
    """
    Listeyi bir doğruluk tablosuna çevirir. Listenin değerlerinin sıralı olduğu
    varsayılır.
    """
    n = math.log2(len(x))
    if not n.is_integer():
        raise Exception("Length of list should be power of 2")
    return dict(zip(generate_tuples(int(n)), x))

def tuple_op(*tuples, op=xor):
    """
    Tuple içindeki elemanları karşılıklı olarak `op` işleminden geçirir.
    Tuple'ların aynı uzunlukta olması gerekir.
    ```
    > tuple_op((0,1), (1,0), op=xor)
    (1, 1)
    > tuple_op((0,1), (1,0), (0,1), op=add)
    (1, 2)
    ```
    """

    if len(set(len(t) for t in tuples)) != 1:
        raise Exception("Tuple'ların uzunlukları aynı değil.")

    return tuple(reduce(op, i) for i in zip(*tuples))

class AttrFree:
    """
    Bu sınıfın amacı `int`, `str`, `bool` gibi temel sınıfların attribute
    eklebilir versiyonlarnı sağlamak. Örneğin bir `int` için şunu yapamazsınız:

    ```
    > x = int(2)
    > x.ornek_bir_attr = "test"
    ...
    AttributeError: 'int' object has no attribute 'ornek_bir_attr'
    ```

    Ancak bu sınıfın öğeleri ile bunu yapmak mümkün:

    ```
    > x = AttrFree.int(2)
    > x.ornek_bir_attr = "test"
    > x.ornek_bir_attr
    'test'
    ```

    """

    class int(int):
        pass

class Term:
    """
    `Boole.algebraic_degree` metodu için eklenmiş sınıf. Boole fonksiyonunun
    doğruluk tablosundan cebirsel ifadesinin elde edilmesi için kullanılır.
    """

    def __init__(self, *items):
        if all(type(i) == int for i in items):
            self.items = set(items)
        else:
            raise Exception("Use only integers")

    def __str__(self):
        # for latex
        return "".join(f"x_{i}" for i in self.items)

    def __repr__(self):
        # for debug
        return f"<{ ' '.join(str(i) for i in self.items) }>"

    def __eq__(self, other):
        return self.items == other.items

    def __rmul__(self, other):
        u = set()
        u = u.union(self.items)
        if type(other) != int:
            u = u.union(other.items)
        return Term(*u)

    def __mul__(self, other):
        return self.__rmul__(other)

    @classmethod
    def generate_eq_part(cls, t):
        part = []
        for index, item in enumerate(t, 1):
            if item == 1:
                part.append( [Term(index)] )
            elif item == 0:
                part.append( [Term(index), 1] )
        return part

    @classmethod
    def expand_parts(cls, a:list, b:list):
        return [x * y for x, y in product(a, b)]

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
        self._n = None

        if type(dict_or_func) == dict:
            key_lens = set(map(len, dict_or_func.keys()))
            if len(key_lens) > 1:
                raise Exception("Dict'te sorun var")

            self._truth_table = dict_or_func.copy()
            self._n = key_lens.pop()
        elif callable(dict_or_func):
            self._method = dict_or_func

            n = 0
            while True:
                try:
                    self._method(tuple(0 for i in range(n)))
                except (IndexError, TypeError):
                    n += 1
                else:
                    self._n = n
                    break

    def __call__(self, *args):
        if len(args) != self.n:
            raise TypeError(f"This Boole func takes exactly {self.n} argument "+
                f"({len(args)} given)")
        elif self._method:
            return self._method(args)
        elif self._truth_table:
            return self._truth_table[args]
        else:
            raise NotImplementedError("Boole fonksiyonu için doğruluk tablosu "+
                "veya fonksiyon girilmedi")

    @property
    def n(self):
        return self._n

    @property
    def truth_table(self):
        if self._truth_table:
            return self._truth_table.copy()

        return {t: self(*t) for t in generate_tuples(self.n)}

    def nonlinearity(self):
        """
        Boole fonksiyonunun doğrusal olmama değerini verir.
        `AttrFree.int` döndürür, eklenen attr'ler:
        - .functions
        - .X
        - .X_d
        - .inv_X
        - .inv_X_d
        """

        # truth_table sıralı değildir, sıralı biçimde tüm değerlerin
        # alınabilmesi için `generate_tuples` kullanıldı
        target = list(self(*t) for t in generate_tuples(self.n))

        # Tüm lineer fonksiyonlar
        functions = [linear_function(*t) for t in generate_tuples(self.n)]

        # Lineer fonksiyonların tüm durumlara yanıtları.
        X = []
        for f in functions:
            X.append([f(*t) for t in generate_tuples(self.n)])

        inv_X = bool_inverse(X)

        X_d = [hamming_dist(target, row) for row in X]
        inv_X_d = [hamming_dist(target, row) for row in inv_X]

        result = AttrFree.int(min(X_d + inv_X_d))
        result.functions = functions
        result.X = np.array(X).T.tolist()
        result.X_d = X_d
        result.inv_X = np.array(inv_X).T.tolist()
        result.inv_X_d = inv_X_d
        return result

    def autocorr_func(self):
        """
        Boole fonksiyonunun otokorelasyon fonksiyonunu verir.
        Bir `function` döndürür.

        Döndürülen fonksiyon tuple alır.
        AttrFree.int döndürür, ona eklenen attr'lar:
        - .repr
        """

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

    def absolute_indicator(self):
        """Boole fonksiyonunun mutlak gösterge değeri.
        Otokorelasyon fonksiyonunu tüm tuple'ları (d=(0,0...0) hariç) dener ve
        mutlak değerce en büyüğünü döndürür.
        
        AttrFree.int döndürür, ona eklenen attr'lar:
        - .values
        """

        tuples = generate_tuples(self.n)
        next(tuples) # ilk tuple'ı çıkardık

        f = self.autocorr_func()
        values = [abs(f(*t)) for t in tuples]
        result = AttrFree.int(max(values))
        result.values = values
        return result

    def algebraic_degree(self):
        """
        Boole fonksiyonunun cebirsel derecesini verir. Önce fonksiyonun
        cebirsel ifadesini elde eder. Bulunan cebirsel ifadede, çarpım halinde
        kullanılan en yüksek değişken sayısıdır.

        AttrFree.int döndürür, eklenen attr'lar:
        - .history
        """

        # sadeleştirme adımları için geçmişi tutuyoruz
        history = []
        # fonksiyonun true olduğu durumlar
        true_tuples = [t for t in generate_tuples(self.n) if self(*t)]

        # terimler oluşturuluyor
        equation = [Term.generate_eq_part(t) for t in true_tuples]
        history.append(deepcopy(equation))

        # terimlerin kendi içinde kartezyen çarpımları
        for i in range(len(equation)):
            while len(equation[i]) > 1:
                a, b = equation[i].pop(), equation[i].pop()
                equation[i].append(Term.expand_parts(a, b))

            # böyle bir ihtimal yok ama öylesine yazdım
            if len(equation[i]) == 0:
                del equation[i]
            else:
                equation[i] = equation[i][0]

        history.append(deepcopy(equation))
        # [[]], [[]] --> [], []
        equation = sum(equation, [])

        # sadeleştirme: aynı terimden bir tane daha varsa sil
        i = 0
        while i < len(equation):
            if equation[i] not in equation[i+1:]:
                i += 1
                continue
            pos = equation.index(equation[i], i+1)
            del equation[pos], equation[i]

        history.append(deepcopy(equation))
        result = AttrFree.int(max(len(term.items) for term in equation))
        result.history = history
        return result


def _get_latex_doc(landscape=False, margin="1in"):
    doc = pylatex.Document(
        document_options=["a4paper","12pt"] +
            ["landscape"] if landscape else []
        ,
        geometry_options={"margin": margin},
    )
    doc.content_separator = "%\n\n"
    doc.packages.append(pylatex.Package("enumitem"))
    doc.preamble.append(
        pylatex.UnsafeCommand("setlength", r"\parskip", extra_arguments="1em")
    )

    return doc
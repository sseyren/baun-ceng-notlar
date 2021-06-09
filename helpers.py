from functools import reduce
from operator import xor
import math
import numpy as np
import pylatex

def generate_tuples(n=2):
    """
    Sıralı tuple'lar oluşturur. Örneğin `n=2` için
    `(0,0) (0,1) (1,0) (1,1)` gibi tuple'lar oluşturur.

    Generator döndürür.
    """

    counter = 0
    for _ in range(pow(2, n)):
        bitstr = format(counter, f"0{n}b")
        yield tuple(int(b) for b in bitstr)
        counter += 1

def linear_function(*coeff):
    """
    Tuple katsayıları alır ve lineer fonksiyonu döndürür. Dönen fonksiyonların
    tuple'daki eleman sayısı kadar girdi alması gerekir.
    """
    f = lambda *x: reduce(xor, [x[num] * c for num, c in enumerate(coeff)])

    # string representation
    # TOOD: make this latex repr or add one
    f.repr = " ^ ".join(f"{c}*x{num}" for num, c in enumerate(coeff, 1))
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
        target = list(self.truth_table[t] for t in generate_tuples(self.n))

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


def _get_latex_doc():
    doc = pylatex.Document(
        document_options=["a4paper","12pt"],
        geometry_options={"margin": "1in"},
    )
    doc.content_separator = "%\n\n"
    doc.preamble.append(
        pylatex.UnsafeCommand("setlength", r"\parskip", extra_arguments="1em")
    )

    return doc
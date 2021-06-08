import numpy as np

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
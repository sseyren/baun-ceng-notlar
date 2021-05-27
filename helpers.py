
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
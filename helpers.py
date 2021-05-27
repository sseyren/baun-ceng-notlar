
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
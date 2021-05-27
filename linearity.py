from functools import reduce
from operator import xor

from helpers import generate_tuples

def linear_function(*coeff):
    """
    Tuple katsayıları alır ve lineer fonksiyonu döndürür. Dönen fonksiyonların
    tuple'daki eleman sayısı kadar girdi alması gerekir.
    """
    f = lambda *x: reduce(xor, [x[num] * c for num, c in enumerate(coeff)])

    # string representation
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

def inverse_corpus(X_in:list):
    X = []
    for row in X_in:
        X.append([int(not i) for i in row])

    return X

def main(target:list, n=2):
    print(f"Girdi vektörü: {target}")

    tuples = list(generate_tuples(n))
    print(f"Tüm girdiler: {tuples}")
    print()

    # Tüm lineer fonksiyonlar
    functions = [linear_function(*t) for t in tuples]

    print("Lineer fonksiyonlar:")
    for i, f in enumerate(functions, 1):
        print(f"f{i}: {f.repr}")
    print()

    # Lineer fonksiyonların tüm durumlara yanıtları.
    X = []
    for f in functions:
        X.append([f(*t) for t in tuples])

    inv_X = inverse_corpus(X)

    distances = []

    print("Satırlar sırasıyla fonksiyonlar, sütunlar sırasıyla tüm girdiler,")
    print("son kısım ise hedef vektör ile arasındaki uzaklık.")
    for row in X:
        dist = hamming_dist(target, row)
        distances.append(dist)
        print(f"{row}  {dist}")
    print()

    print("Bu matrisin tümleyeninde durum:")
    for row in inv_X:
        dist = hamming_dist(target, row)
        distances.append(dist)
        print(f"{row}  {dist}")
    print()

    result = min(distances)
    print(f"Uzaklıklar içinde en küçüğü: {result}")

    return result

if __name__ == "__main__":
    main([0,0,1,0,1,1,0,1], 3)
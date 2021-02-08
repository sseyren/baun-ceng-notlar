import os, sys
import numpy as np

from helpers import euclidean_distance

class KNN:
    def __init__(self, k=3):
        self.k = k

    def fit(self, x:np.ndarray, y:np.ndarray):
        self.train = x
        self.target = y

    def predict_one(self, a:np.ndarray):
        distances = np.array([euclidean_distance(a, x) for x in self.train])
        print("Bu noktanın veri setindeki diğer noktalara uzaklıkları:")
        print(distances, end=os.linesep*2)

        k_index = np.argsort(distances)[:self.k]
        print(f"Bu noktaya en yakın {self.k} noktanın indisleri (1-den başlar):")
        print(k_index+np.ones(self.k), end=os.linesep*2)

        k_label = [self.target[i] for i in k_index]
        print("İndislerin karşılık geldiği etiketler:")
        print(k_label, end=os.linesep*2)

        majority = max(set(k_label), key=k_label.count)
        print("En çok geçen etiket:")
        print(majority, end=os.linesep*2)
        return majority

if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

    X = np.array([
        [10, 1, 0],
        [4, 4, 2],
        [4, -2, 4],
        [2, 3, 4],
        [1, -3, 3],
        [-2, 8, 1],
        [-3, 3, 3],
        [-4, 0, -4],
    ])
    y = np.array([
        1,
        1,
        0,
        1,
        0,
        1,
        0,
        0,
    ])

    model = KNN(k=3)
    model.fit(X, y)

    result = model.predict_one(np.array([2, -3, 4]))
    print(f"Sonuç: {result}")
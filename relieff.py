import os
import numpy as np

from helpers import manhattan_distance

class ReliefF:
    def __init__(self, k=1):
        self.k = k

    def fit(self, X, y):
        n_samples, n_features = X.shape

        self.weights = np.zeros(n_features)
        print(f"Ağırlık vektörü: {self.weights}")

        self.max_vec = X.max(axis=0)
        self.min_vec = X.min(axis=0)

        self.X_y = np.append(np.copy(X), [[l] for l in y], axis=1)
        self.classes = np.unique(y)
        self.priors = np.array([
            np.count_nonzero(y == i) / n_samples
            for i in self.classes
        ])
        print(f"Her sınıf için önsel olasılıklar: {self.priors}")
        print()

        for x_i, x in enumerate(X):
            x_class = y[x_i]
            print(f"{x} (sınıf {x_class}) için")
            print()

            class_members = self.X_y[self.X_y[:, -1] == x_class]
            other_members = self.X_y[self.X_y[:, -1] != x_class]

            same_class_neighbors = self._get_neighbors(x, class_members)
            other_class_neighbors = self._get_neighbors(x, other_members)

            print(f"Aynı sınıfta bulunan en yakın {self.k} komşu:")
            for q_class, q in same_class_neighbors:
                print(f" {q} (sınıf {q_class}) ({self.__i_by_value(q)}. satır)")

            print(f"Farklı sınıflarda bulunan en yakın {self.k} komşu:")
            for q_class, q in other_class_neighbors:
                print(f" {q} (sınıf {q_class}) ({self.__i_by_value(q)}. satır)")
            print()

            dH = sum((self._diff(x, q) / n_samples) for q_class, q in same_class_neighbors) * (1 / self.k)
            dM = sum((self.priors[q_class] / (1-self.priors[x_class])) * (self._diff(x, q) / n_samples) for q_class, q in other_class_neighbors) * (1 / self.k)
            print(f"dH: {dH}")
            print(f"dM: {dM}")
            print()

            update = -dH + dM
            new_weights = self.weights + update
            print("-dH + dM = güncelleme")
            print("mevcut ağırlıklar + güncelleme = yeni ağırlıklar")
            print(f"{self.weights} + {update} = {new_weights}")
            print(os.linesep)

            self.weights = new_weights

    def _get_neighbors(self, x, array):
        "`array` içindeki en yakın `self.k` adet komşuyu verir"
        distances = [
            # uzaklık, sınıf, vektörün kendisi
            (manhattan_distance(x, vec[:-1]), vec[-1], vec[:-1])
            for vec in array
        ]
        sorted_dist = list(sorted(distances, key=lambda item: item[0]))
        if sorted_dist[0][0] == 0:
            sorted_dist = sorted_dist[1:]
        sorted_dist = sorted_dist[0:self.k]
        return list(map(lambda item:item[1:], sorted_dist))

    def _diff(self, a, b):
        return np.abs(a - b) / (self.max_vec - self.min_vec)

    def __i_by_value(self, row):
        return np.where((self.X_y[:,:-1] == row).all(axis=1))[0][0] + 1


if __name__ == "__main__":
    X = np.array([
        [ 3,  7, -1],
        [ 0,  4,  2],
        [ 1,  1,  5],
        [-3,  2,  7],
        [ 1,  0,  0],
        [ 2,  4, -3],
    ])
    # y mutlaka 0'dan başlamalı ve ardışık olarak artmalı
    y = np.array([
        0,
        0,
        0,
        1,
        1,
        1,
    ])

    r = ReliefF()
    r.fit(X, y)
    print("Sonuç olarak ağırlık vektörünün son durumu:")
    print(r.weights)
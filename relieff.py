import os, sys
import numpy as np

from helpers import manhattan_distance

class ReliefF:
    def __init__(self, k=1):
        self.k = k

    def fit(self, X, y):
        n_samples, n_features = X.shape

        # X_y: X ile y nin birleşmiş hali, bu matrisin her satırı:
        # [index, x_1[1], x_1[2], ..., x_1[n_features], class label]
        self.X_y = np.append(np.copy(X), [[l] for l in y], axis=1)
        self.X_y = np.append([[i] for i in range(1, n_samples+1)], self.X_y, axis=1)

        print("X matrisinin satırları:")
        for row in self.X_y:
            i, vec, label = row[0], row[1:-1], row[-1]
            print(f"x_{i}: {vec}  (sınıf {label})")
        print()

        self.weights = np.zeros(n_features)
        print(f"Ağırlık vektörü: {self.weights}")
        print(f"m (satır sayısı) = {n_samples}")
        print()

        self.classes = np.unique(y)
        self.priors = np.array([
            np.count_nonzero(y == i) / n_samples
            for i in self.classes
        ])
        for i in self.classes:
            print(f"p_{i} ({i} sınıfı için önsel olasılık) = {self.priors[i]}")
        print("(sınıfa ait satır sayısı / toplam satır sayısı)")
        print()

        self.max_vec = X.max(axis=0)
        self.min_vec = X.min(axis=0)
        print(f"v_min (minimum vektörü): {self.min_vec}")
        print("(X matrisinin her sütununun en küçük değeri)")
        print(f"v_max (maksimum vektörü): {self.max_vec}")
        print("(X matrisinin her sütununun en büyük değeri)")
        print(os.linesep)

        for row in self.X_y:
            x_i, x, x_class = row[0], row[1:-1], row[-1]
            print(f"---> x_{x_i}: {x} (sınıf {x_class}) için")
            print()

            class_members = self.X_y[self.X_y[:, -1] == x_class]
            other_members = self.X_y[self.X_y[:, -1] != x_class]

            print("Aynı sınıfta bulunan diğer elemanlar:")
            same_class_neighbors = self._get_neighbors(x, x_i, class_members)
            print(f"Bunlardan en yakın {self.k} komşu:")
            for q_class, q_i, q in same_class_neighbors:
                print(f" x_{q_i}: {q} (sınıf {q_class})")
            print()

            for q_class, q_i, q in same_class_neighbors:
                print(f"d(x_{x_i}, x_{q_i}) = {self._diff(x, q, x_i, q_i)}")
                print()

            dH = sum(
                self._diff(x, q) / n_samples
                for q_class, q_i, q in same_class_neighbors
            )
            dH_repr1 = "+".join(
                f" (d(x_{x_i}, x_{q_i}) / m={n_samples}) "
                for q_class, q_i, q in same_class_neighbors
            )
            dH_repr2 = "+".join(
                f" {self._diff(x, q) / n_samples} "
                for q_class, q_i, q in same_class_neighbors
            )
            dH = dH * (1 / self.k)
            print(f"dH = ({dH_repr1}) * (1/k={self.k})")
            print(f"dH = ({dH_repr2}) * {1/self.k}")
            print(f"dH = {dH}")
            print()

            print("Farklı sınıflarda bulunan diğer elemanlar:")
            other_class_neighbors = self._get_neighbors(x, x_i, other_members)
            print(f"Bunlardan en yakın {self.k} komşu:")
            for q_class, q_i, q in other_class_neighbors:
                print(f" x_{q_i}: {q} (sınıf {q_class})")
            print()

            for q_class, q_i, q in other_class_neighbors:
                print(f"d(x_{x_i}, x_{q_i}) = {self._diff(x, q, x_i, q_i)}")
                print()

            dM = sum(
                (self.priors[q_class] / (1-self.priors[x_class])) * (self._diff(x, q) / n_samples)
                for q_class, q_i, q in other_class_neighbors
            )
            dM_repr1 = "+".join(
                f" ((p_{q_class} / 1-p_{x_class}) * (d(x_{x_i}, x_{q_i}) / m={n_samples})) "
                for q_class, q_i, q in other_class_neighbors
            )
            dM_repr2 = "+".join(
                f" ({self.priors[q_class] / (1-self.priors[x_class])} * {self._diff(x, q) / n_samples}) "
                for q_class, q_i, q in other_class_neighbors
            )
            dM = dM * (1 / self.k)
            print(f"dM = ({dM_repr1}) * (1/k={self.k})")
            print(f"dM = ({dM_repr2}) * {1/self.k}")
            print(f"dM = {dM}")
            print(os.linesep)

            update = -dH + dM
            new_weights = self.weights + update
            print(f"-dH + dM = {update} (güncelleme)")
            print("mevcut ağırlıklar + güncelleme = yeni ağırlıklar")
            print(f"{self.weights} + {update} = {new_weights}")
            print(os.linesep)

            self.weights = new_weights

    def _get_neighbors(self, x, x_i, array):
        "`array` içindeki en yakın `self.k` adet komşuyu verir"
        distances = [
            # uzaklık, sınıf, indis, vektörün kendisi
            (manhattan_distance(x, vec[1:-1]), vec[-1], vec[0], vec[1:-1])
            for vec in array
        ]
        sorted_dist = list(sorted(distances, key=lambda item: item[0]))
        if sorted_dist[0][0] == 0:
            sorted_dist = sorted_dist[1:]

        for t in sorted_dist:
            print(f" manhattan(x_{x_i}, x_{t[2]}) = {t[0]}")

        sorted_dist = sorted_dist[0:self.k]
        # sınıf, indis, vektörün kendisi
        return list(map(lambda item:item[1:], sorted_dist))

    def _diff(self, a, b, a_i=None, b_i=None):
        if a_i != None and b_i != None:
            print(f"d(x_{a_i}, x_{b_i}) = |x_{a_i} - x_{b_i}| / v_max - v_min")
            print(f"|x_{a_i} - x_{b_i}| = {np.abs(a - b)}")
            print(f"v_max - v_min = {self.max_vec - self.min_vec}")

        return np.abs(a - b) / (self.max_vec - self.min_vec)


if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

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
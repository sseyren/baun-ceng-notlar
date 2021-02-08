import os, sys
import numpy as np

from helpers import euclidean_distance, print_arr

class KMeans:
    def __init__(self, k=2):
        self.k = k

    def get_empty_clusters(self):
        return [[] for i in range(self.k)]

    def get_dist_matrix(self):
        l = []
        for p in self.X:
            l.append([euclidean_distance(p, c) for c in self.centroids])
        return np.array(l)

    def new_clusters(self):
        new_clusters = self.get_empty_clusters()
        dist = self.get_dist_matrix()

        for i, d in enumerate(dist):
            cluster = np.argsort(d)[0]
            new_clusters[cluster].append(i)

        return new_clusters

    def new_centroids(self):
        l = []
        for cluster in self.clusters:
            merged = np.array([self.X[index] for index in cluster])
            l.append(np.average(merged, axis=0))

        return np.array(l)

    def fit(self, X:np.ndarray):
        self.X = X
        print("X'in satırları:")
        self._list_vecs(X, "x")
        print()

        self.clusters = self.get_empty_clusters()
        self.centroids = np.copy(X[0:self.k])
        print(f"İterasyona başlamadan önce X'in ilk {self.k} satırını " +
            "merkez noktalar olarak seçiyoruz.")
        self._list_vecs(self.centroids)
        print(os.linesep)

        iteration = 0
        while True:
            iteration += 1
            print(f"İterasyon: {iteration}")
            print()

            print("Mevcut merkezler:")
            self._list_vecs(self.centroids)
            print()

            dist_matrix = self.get_dist_matrix()
            print("Mevcut merkezlerle noktaların uzaklık matrisi:")
            print_arr(dist_matrix, col_prefix="c")
            print()

            new_clusters = self.new_clusters()
            print("x_'leri kendisine en yakın merkezlerin bulunduğu kümelere koyuyoruz.")
            print("Yeni kümeler:")
            for i, cluster in enumerate(new_clusters, 1):
                elements = ", ".join(f"x_{j+1}" for j in cluster)
                print(f"{i} -> {elements}")
            print()

            if new_clusters == self.clusters:
                print("Önceki kümeler, yeni kümelerle aynı.")
                print("İterasyon sonlandı.")
                break

            print(
                "Yeni kümeler, önceki kümelerden farklı, " +
                "yeni merkezler hesaplanmalı."
            )
            print("Kümenin elemanlarının ortalamaları kümenin yeni merkezini verir.")
            print()

            self.clusters = new_clusters
            self.centroids = self.new_centroids()

            print("Yeni Merkezler:")
            for cluster_i, cluster in enumerate(self.clusters):
                formula = ", ".join(f"x_{x+1}" for x in cluster)
                print(f"c_{cluster_i+1} = ort({formula}) = {self.centroids[cluster_i]}")

            print(os.linesep)

    def _list_vecs(self, arr, prefix="c"):
        for v_i, v in enumerate(arr, 1):
            print(f"{prefix}_{v_i} = {v}")

if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

    X = np.array([
        [5, 3],
        [7, 2],
        [1, 4],
        [6, 3],
        [0, 5],
        [8, 4],
        [-3, 2],
        [4, 1],
    ])

    model = KMeans(k=2)
    model.fit(X)
import numpy as np
import os

from helpers import euclidean_distance

class KMeans:
    def __init__(self, k=2):
        self.k = k

    def get_empty_clusters(self):
        return [[] for i in range(self.k)]

    def fit(self, x:np.ndarray):
        self.points = x
        self.clusters = self.get_empty_clusters()
        self.centroids = np.copy(self.points[0:self.k])

    def get_dist_matrix(self):
        l = []
        for p in self.points:
            l.append([euclidean_distance(p, c) for c in self.centroids])

        arr = np.array(l)
        print("Mevcut merkezlerle noktaların uzaklık matrisi:")
        print(arr)
        return arr

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
            merged = np.array([self.points[index] for index in cluster])
            l.append(np.average(merged, axis=0))

        return np.array(l)

    def calculate(self):
        iteration = 0
        while True:
            iteration += 1
            print(f"İterasyon: {iteration}")

            print("Mevcut merkezler:")
            print(self.centroids)

            new_clusters = self.new_clusters()
            print("Kümeler:")
            for i, cluster in enumerate(new_clusters, 1):
                print(f"{i} -> {[j+1 for j in cluster]}")

            if new_clusters == self.clusters:
                print("Önceki kümeler, yeni kümelerle aynı.")
                print("İterasyon sonlandı.")
                break

            print(
                "Yeni kümeler, önceki kümelerden farklı, " +
                "yeni merkezler hesaplanmalı."
            )
            self.clusters = new_clusters
            self.centroids = self.new_centroids()
            print("Yeni Merkezler:")
            print(self.centroids)
            print()

if __name__ == "__main__":
    model = KMeans(k=2)
    model.fit(np.array([
        [5, 3],
        [7, 2],
        [1, 4],
        [6, 3],
        [0, 5],
        [8, 4],
        [-3, 2],
        [4, 1],
    ]))

    model.calculate()
import os, sys
import numpy as np

from helpers import euclidean_distance, print_arr

class LOF:
    def __init__(self, k=2):
        self.k = k
        print(f"k = {self.k}")
        print()

    def dist_array(self, index:int):
        """Bir noktanın (kendisi dahil) başka noktalara olan uzaklıkları."""
        return [euclidean_distance(self.X[index], n)
            for n in self.X]

    def k_distance(self, index:int):
        """Bir noktanın k-uzaklığı."""
        d_arr = np.copy(self.dist_matrix[index])
        d_arr.sort()
        # en yakın k. noktayı almak için [self.k-1] indisini kullanmamız gerekirdi
        # fakar d_arr içinde mutlaka bir 0 değeri var, o yüzden d_arr[self.k]
        # yanlış bir ifade olmuyor
        return d_arr[self.k]

    def k_neighbors(self, index:int):
        """Bir noktanın k-komşuları."""
        k_dist = self.k_dist_matrix[index]
        d_arr = list(enumerate(self.dist_matrix[index]))
        neighbors = list(filter(lambda x: x[1] <= k_dist and x[1] != 0, d_arr))
        return [i for i, _ in neighbors]

    def reachability_distance(self, i:int, j:int):
        return max(
            self.k_dist_matrix[j],
            euclidean_distance(self.X[i], self.X[j])
        )

    def LRD(self, i:int):
        neighbors = self.k_neigh_array[i]
        sum_rd = 0
        for j in neighbors:
            sum_rd += self.reach_dist_matrix[i, j]

        return len(neighbors) / sum_rd

    def LOF(self, i:int):
        neighbors = self.k_neigh_array[i]
        sum_lrd = 0
        for j in neighbors:
            sum_lrd += self.LRD(j)

        result = (sum_lrd / len(neighbors)) / self.LRD(i)
        return result

    def fit(self, X:np.ndarray):
        self.X = X
        print("X (girdi) matrisinin satırları (elemanları):")
        print_arr(X, header=False)
        print()

        self.dist_matrix = np.array([self.dist_array(i) for i in range(len(X))])
        print("Noktaların birbirlerine olan (öklid) uzaklıkların matrisi:")
        print_arr(self.dist_matrix, label="d()")
        print()

        self.k_dist_matrix = np.array([self.k_distance(i) for i in range(len(X))])
        print("Noktaların K-Uzaklıkları:")
        print(f"(noktaya en yakın k. ({self.k}.) noktanın uzaklığı)")
        for dist_i, dist in enumerate(self.k_dist_matrix, 1):
            print(f"kd(x_{dist_i}) = {dist:<8.3f}")
        print()

        self.k_neigh_array = [self.k_neighbors(i) for i in range(len(X))]

        self.reach_dist_matrix = []
        for i in range(len(X)):
            self.reach_dist_matrix.append(
                [self.reachability_distance(i, j) for j in range(len(X))]
            )
        self.reach_dist_matrix = np.array(self.reach_dist_matrix)
        print("Reachability Distance matrisi:")
        print("rd(x, y) = max(kd(y), d(x,y))")
        print_arr(self.reach_dist_matrix, label="rd()")
        print()

        print("Her noktanın k-komşular listesi:")
        for i in range(len(X)):
            print("N_k({}) = {}".format(
                f"x_{i+1}",
                ", ".join([f"x_{j+1}" for j in self.k_neigh_array[i]])
            ))
        print()

        print("Her nokta için LRD:")
        for i in range(len(X)):
            rd_formula = " + ".join(f"rd(x_{i+1}, x_{j+1})" for j in self.k_neigh_array[i])
            print(f"LRD(x_{i+1}) = |N_k(x_{i+1})|={len(self.k_neigh_array[i])} / ( {rd_formula} )")
            print(f"LRD(x_{i+1}) = {self.LRD(i):.3f}")
            print()

        print("Her nokta için LOF:")
        for i in range(len(X)):
            lrd_formula = " + ".join(f"LRD(x_{j+1})" for j in self.k_neigh_array[i])
            print(f"LOF(x_{i+1}) = ( {lrd_formula} ) / ( |N_k(x_{i+1})|={len(self.k_neigh_array[i])} * LRD(x_{i+1}) )")
            print(f"LOF(x_{i+1}) = {self.LOF(i):.3f}")
            print()


if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

    X = np.array([
        [2,3],
        [1,4],
        [0,2],
        [1,3],
    ])

    model = LOF(k=2)
    model.fit(X)
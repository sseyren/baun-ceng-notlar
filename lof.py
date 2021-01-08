import numpy as np
import os

from helpers import euclidean_distance

class LOF:
    def __init__(self, k=2):
        self.k = k

    def fit(self, points:np.ndarray):
        self.points = points
        self.dist_matrix = np.array([self.dist_array(i)
            for i in range(len(self.points))])
        self.k_dist_matrix = np.array([self.k_distance(i)
            for i in range(len(self.points))])
        self.k_neigh_array = [self.k_neighbors(i)
            for i in range(len(self.points))]

        self.reach_dist_matrix = []
        for i in range(len(self.points)):
            self.reach_dist_matrix.append(
                [self.reachability_distance(i, j) for j in range(len(self.points))]
            )
        self.reach_dist_matrix = np.array(self.reach_dist_matrix)

    def dist_array(self, index:int):
        """Bir noktanın (kendisi dahil) başka noktalara olan uzaklıkları."""
        return [euclidean_distance(self.points[index], n)
            for n in self.points]

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
            euclidean_distance(self.points[i], self.points[j])
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

    def compute_all(self):
        print("Noktaların birbirlerine olan uzaklıkların matrisi:")
        print(self.dist_matrix, end=os.linesep*2)

        print("Noktaların K-Uzaklıkları:")
        print(self.k_dist_matrix, end=os.linesep*2)

        print("Reachability Distance matrisi:")
        print(self.reach_dist_matrix, end=os.linesep*2)

        for i in range(len(self.points)):
            print(f"Nokta {i+1}:")
            print(" k-komşular: {}".format(
                [x+1 for x in self.k_neigh_array[i]]
            ))
            print(" LRD: {}".format(self.LRD(i)))
            print(" LOF: {}".format(self.LOF(i)))

if __name__ == "__main__":
    class cases:
        case1 = np.array([
            [1,1],
            [1,2],
            [2,1],
            [3,3],
        ])
        case2 = np.array([
            [2,3],
            [1,4],
            [0,2],
            [1,3],
        ])

    model = LOF(k=2)
    model.fit(cases.case2)
    model.compute_all()
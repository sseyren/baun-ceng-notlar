# Based on https://github.com/python-engineer/MLfromscratch/blob/master/mlfromscratch/lda.py
# Thanks to https://github.com/python-engineer

import os, sys
from itertools import zip_longest
import numpy as np

class LDA:

    def _print_two_arr(self, title_a, title_b, a, b, sep="\t\t\t"):
        print(str(title_a) + sep + str(title_b))
        for x, y in zip_longest(a, b, fillvalue=""):
            print(str(x) + sep + str(y))

    def fit(self, X, y):
        n_features = X.shape[1]
        class_labels = np.unique(y)
        mean_vecs = {}
        S_vecs = {}

        S_w = np.zeros((n_features, n_features))
        for c in class_labels:
            X_c = X[y == c]
            mean_c = np.mean(X_c, axis=0)
            mean_vecs[c] = mean_c

            print(f"{c} sınıfı için ortalama vektörü (m_{c}): {mean_c}")
            print(f"X'in {c} sınıfındaki elemanları X_{c} için:")
            print(f"X_{c}:")
            print(X_c)
            print()

            print(f"S_{c} = (X_{c} - m_{c}) . (X_{c} - m_{c})^T ")
            print()

            self._print_two_arr(
                f"(X_{c} - m_{c}):",  "Bunun transpozu:",
                X_c - mean_c,         (X_c - mean_c).T
            )
            print()

            # (4, n_c) * (n_c, 4) = (4,4) -> transpose
            S_c = (X_c - mean_c).T.dot((X_c - mean_c))
            print(f"S_{c}:")
            print(S_c)
            print()

            S_vecs[c] = S_c

        print()

        S_w = sum(S_vecs.values())
        S_w_inv = np.linalg.inv(S_w)

        print("S_w = " + " + ".join(f"S_{i}" for i in class_labels))
        print()
        self._print_two_arr(
            "S_w:", "ters(S_w):",
            S_w,    S_w_inv
        )
        print()

        mean_equation = "(" + " - ".join(f"m_{i}" for i in class_labels) + ")"
        print(f"w = ters(S_w) . {mean_equation}")
        print()

        mean_sum = mean_vecs[class_labels[0]] + sum(-v for k, v in mean_vecs.items() if k != class_labels[0])
        print(f"{mean_equation}:")
        print(mean_sum)
        print()

        self.weights = np.dot(S_w_inv, mean_sum)
        print("w:")
        print(self.weights)
        print(os.linesep)

        return self.weights

    def transform(self, X):
        # project data
        for x in X:
            print(f"{x} . {self.weights} = {np.dot(x, self.weights):.3f}")

        return np.dot(X, self.weights)

if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

    X = np.array([
        [1, 2],
        [2, 3],
        [3, 4.9],
        [2, 1],
        [3, 2],
        [4, 3.9],
    ])
    y = np.array([
        0,
        0,
        0,
        1,
        1,
        1,
    ])

    lda = LDA()
    lda.fit(X, y)

    print("Bu modele göre yeni a değerleri:")
    lda.transform(X)
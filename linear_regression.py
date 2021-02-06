# Based on https://github.com/python-engineer/MLfromscratch/blob/master/mlfromscratch/linear_regression.py
# Thanks to https://github.com/python-engineer

import os, sys
import numpy as np

class LinearRegression:

    def __init__(self, learning_rate=0.001, n_iters=1000):
        self.lr = learning_rate
        self.n_iters = n_iters
        self.weights = None
        self.bias = None

    def fit(self, X, y):
        n_samples, n_features = X.shape

        print("X matrisi (girdi):")
        print(X)
        print()
        print(f"m (satır sayısı) = {n_samples}")
        print()
        print("y vektörü:")
        print(y)
        print("(X matrisindeki her satır için sonuçlar)")
        print()
        print(f"lr = {self.lr}")
        print("(öğrenme oranı)")
        print()

        # init parameters
        self.weights = np.zeros(n_features)
        self.bias = 0
        print("İterasyonlar başlamadan önce:")
        print(f"w (ağırlık vektörü) = {self.weights}")
        print(f"bias = {self.bias}")
        print(os.linesep)

        # gradient descent
        for i in range(1, self.n_iters + 1):
            print(f"İterasyon {i}")
            print()

            y_predicted = np.dot(X, self.weights) + self.bias
            print("Mevcut ağırlıklarla hesaplanan sonuçlar:")
            print("y_p = (X . w) + bias")
            print(f"y_p = {np.dot(X, self.weights)} + {self.bias:.3f}")
            print(f"y_p = {y_predicted}")
            print()

            dy = y_predicted - y
            print("dy = y_p - y")
            print(f"dy = {dy}")
            print()

            # compute gradients
            dw = (1 / n_samples) * np.dot(X.T, dy)
            print(f"dw = (1/m={n_samples}) * (X . dy)")
            print(f"dw = {1/n_samples:.3f} * {np.dot(X.T, dy)}")
            print(f"dw = {dw}")
            print()

            db = (1 / n_samples) * np.sum(dy)
            print(f"db = (1/m={n_samples}) * elemanları_toplamı(dy)")
            print(f"db = {1/n_samples:.3f} * {np.sum(dy):.3f}")
            print(f"db = {db:.3f}")
            print()

            # update parameters
            print("Ağırlıkları (w) güncellemek için dw kullanılacak:")
            print(f"w = w - (lr={self.lr} * dw)")
            print(f"w = {self.weights} - {self.lr * dw}")
            self.weights -= self.lr * dw
            print(f"w = {self.weights}  (yeni ağırlık vektörü)")
            print()

            print("bias'ı güncellemek için db kullanılacak:")
            print(f"bias = bias - (lr={self.lr} * db)")
            print(f"bias = {self.bias:.3f} - {self.lr * db:.3f}")
            self.bias -= self.lr * db
            print(f"bias = {self.bias:.3f}  (yeni bias)")
            print(os.linesep)

        print("Eğitim tamamlandı.")
        print(f"w = {self.weights}  (ağırlık vektörü)")
        print(f"bias = {self.bias:.3f}  (bias)")
        print(os.linesep)

    def predict(self, x):
        print(f"x = {x} için tahmin yapılacak:")
        print("sonuç = (x . w) + bias")
        print(f"sonuç = {np.dot(x, self.weights):.3f} + {self.bias:.3f}")
        y_approximated = np.dot(x, self.weights) + self.bias
        print(f"sonuç = {y_approximated:.3f}")
        return y_approximated


if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

    X = np.array([
        [ 1.53],
        [-1.56],
        [-0.97],
        [-1.23],
        [-1.13],
    ])
    y = np.array([
        94,
        -86,
        -49,
        -67,
        -63,
    ])
    test = np.array([0.14623167])

    regressor = LinearRegression(learning_rate=0.01, n_iters=3)
    regressor.fit(X, y)
    regressor.predict(test)
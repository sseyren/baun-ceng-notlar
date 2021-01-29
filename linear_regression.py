# Based on https://github.com/python-engineer/MLfromscratch/blob/master/mlfromscratch/linear_regression.py
# Thanks to https://github.com/python-engineer

import os
import numpy as np

class LinearRegression:

    def __init__(self, learning_rate=0.001, n_iters=1000):
        self.lr = learning_rate
        self.n_iters = n_iters
        self.weights = None
        self.bias = None

    def fit(self, X, y):
        n_samples, n_features = X.shape

        # init parameters
        self.weights = np.zeros(n_features)
        self.bias = 0
        print(f"İlk durumda ağırlıklar: {self.weights}")
        print(f"İlk durumda bias: {self.bias}")
        print()

        # gradient descent
        for i in range(1, self.n_iters + 1):
            print(f"İterasyon {i}")
            print()

            y_predicted = np.dot(X, self.weights) + self.bias
            print("Mevcut ağırlıklarla hesaplanan sonuçlar:")
            print(y_predicted)
            print()

            # compute gradients
            dw = (1 / n_samples) * np.dot(X.T, (y_predicted - y))
            db = (1 / n_samples) * np.sum(y_predicted - y)
            print(f"d_weights: {dw}")
            print(f"d_bias: {db}")
            print()

            # update parameters
            self.weights -= self.lr * dw
            self.bias -= self.lr * db
            print(f"yeni ağırlıklar: {self.weights}")
            print(f"yeni bias: {self.bias}")
            print(os.linesep)
 

    def predict(self, X):
        y_approximated = np.dot(X, self.weights) + self.bias
        return y_approximated


if __name__ == "__main__":
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
    test = np.array([[0.14623167]])

    regressor = LinearRegression(learning_rate=0.01, n_iters=3)
    regressor.fit(X, y)
    predictions = regressor.predict(test)

    print(f"Bu modele göre sonuçlar:")
    print(predictions)
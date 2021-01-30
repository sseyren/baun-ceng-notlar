# Based on https://github.com/python-engineer/MLfromscratch/blob/master/mlfromscratch/perceptron.py
# Thanks to https://github.com/python-engineer

import numpy as np

class Perceptron:
    def __init__(self, learning_rate=0.1, n_iters=3):
        self.lr = learning_rate
        self.n_iters = n_iters
        self.activation_func = self._unit_step_func
        self.weights = None
        self.bias = None

    def fit(self, X, y):
        n_samples, n_features = X.shape

        # init parameters
        self.weights = np.zeros(n_features)
        self.bias = 0

        # tüm değerlerin 0 veya 1 olması gerek
        y_ = np.array([1 if i > 0 else 0 for i in y])

        print("(I  ) (girdi vektörü . mevcut ağırlıklar) + mevcut bias = lineer çıktı")
        print("(II ) aktivasyon_fonk(lineer çıktı) = tahmin edilen etiket")
        print("(III) öğrenme sabiti * (normal etiket - tahmin edilen etiket) = güncelleme")
        print("(IV ) güncelleme * girdi vektörü = ağırlık güncellemesi")
        print("(V  ) mevcut ağırlık vektörü + ağırlık güncellemesi (IV) = yeni ağırlık vektörü")
        print("(VI ) mevcut bias + güncelleme (III) = yeni bias")
        print()

        for i in range(1, self.n_iters + 1):
            print(f"İterasyon {i}")
            print()

            for idx, x_i in enumerate(X):
                print(f"{x_i} için")
                linear_output = np.dot(x_i, self.weights) + self.bias
                print(f"(I  ) -> ({x_i} . {self.weights}) + {self.bias} = {linear_output}")

                y_predicted = self.activation_func(linear_output)
                print(f"(II ) -> act({linear_output}) = {y_predicted}")

                # Perceptron update rule
                update = self.lr * (y_[idx] - y_predicted)
                print(f"(III) -> {self.lr} * ({y_[idx]} - {y_predicted}) = {update}")

                weights_update = update * x_i
                print(f"(IV ) -> {update} * {x_i} = {weights_update}")

                new_weights = self.weights + weights_update
                print(f"(V  ) -> {self.weights} + {weights_update} = {new_weights}")

                new_bias = self.bias + update
                print(f"(VI ) -> {self.bias} + {update} = {new_bias}")
                print()

                self.weights = new_weights
                self.bias = new_bias

        print("Training bitti.")
        print(f"Ağırlık vektörü: {self.weights}")
        print(f"Bias: {self.bias}")
        print()

    def predict(self, X):
        print(f"{X} için tahmin yapılacak:")

        linear_output = np.dot(X, self.weights) + self.bias
        print(f"(I ) -> ({X} . {self.weights}) + {self.bias} = {linear_output}")

        y_predicted = self.activation_func(linear_output)
        print(f"(II) -> act({linear_output}) = {y_predicted}")
        print()

        return y_predicted

    def _unit_step_func(self, x):
        return np.where(x>=0, 1, 0)


if __name__ == "__main__":
    X = np.array([
        [2, 3],
        [1, 5],
        [3, 6],
        [3, 2],
        [3, 3],
        [2, 6],
    ])
    y = np.array([
        1,
        0,
        0,
        1,
        1,
        0,
    ])
    test = np.array([2, 5])

    p = Perceptron(learning_rate=0.1, n_iters=3)
    p.fit(X, y)
    predictions = p.predict(test)

    print(f"Bu modele göre sonuç:")
    print(predictions)
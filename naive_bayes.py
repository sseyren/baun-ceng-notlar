# Based on https://github.com/python-engineer/MLfromscratch/blob/master/mlfromscratch/naivebayes.py
# Thanks to https://github.com/python-engineer

import os, sys
import numpy as np

from helpers import print_arr

class NaiveBayes:

    def fit(self, X, y):
        n_samples, n_features = X.shape
        self._classes = np.unique(y)
        n_classes = len(self._classes)
        print(f"Sınıflar: {self._classes}")
        print()

        # calculate mean, var, and prior for each class
        self._mean = np.zeros((n_classes, n_features), dtype=np.float64)
        self._var = np.zeros((n_classes, n_features), dtype=np.float64)
        self._priors = np.zeros(n_classes, dtype=np.float64)

        for idx, c in enumerate(self._classes):
            X_c = X[y==c]
            self._mean[idx, :] = X_c.mean(axis=0)
            self._var[idx, :] = X_c.var(axis=0)
            self._priors[idx] = X_c.shape[0] / float(n_samples)

        print("Aşağıdaki iki matris için her satır bir sınıf,")
        print("her sütun bir feature temsil ediyor.")
        print()
        print("Ortalama matrisi:")
        print_arr(self._mean, row_prefix="m", header=False, num_start=0)
        print()
        print("Varyans matrisi:")
        print_arr(self._var, row_prefix="v", header=False, num_start=0)
        print()
        print("Her sınıf için önsel olasılık:")
        for p_i, p in enumerate(self._priors):
            print(f"p_{p_i} = {p:.3f}")
        print(os.linesep)

    def predict(self, x):
        posteriors = []

        print(f"x = {x}")
        print()

        # calculate posterior probability for each class
        for idx in self._classes:
            print(f"{idx} sınıfı için:")

            prior = np.log(self._priors[idx])
            pdf = self._pdf(idx, x)

            pdf_log = np.log(pdf)
            print(f"Bu vektörün log'u: log(P(x|{idx})) = {pdf_log}")

            sum_pdf = np.sum(pdf_log)
            print(f"Vektör bileşenlerin toplamı: {sum_pdf:.3f}")
            print()

            posterior = prior + sum_pdf
            print(f"log(p_{idx}) = {prior:.3f} (önsel olasılık)")
            print(f"Önsel olasılık ile toplamı: log(p_{idx}) + {sum_pdf:.3f} = {posterior:.3f}")
            print(f"{idx} sınıfı için olasılık: {posterior:.3f}")
            print(os.linesep)

            posteriors.append(posterior)

        posteriors = np.array(posteriors)
        print(f"Tüm sınıflar için olasılıklar: {posteriors}")

        # return class with highest posterior probability
        result = self._classes[np.argmax(posteriors)]
        print(f"En yüksek olasılık {result} sınıfında mevcut")

        return result

    def _pdf(self, idx, x):
        print("exp(x) = e^x")
        print("sqrt(x) = x'in karekökü")

        mean = self._mean[idx]
        var = self._var[idx]

        numerator = np.exp(- (x-mean)**2 / (2 * var))
        denominator = np.sqrt(2 * np.pi * var)

        print(f"P(x|{idx}) = pay / payda")
        print()

        print(f"pay = exp( -(x - m_{idx})^2 / 2 * v_{idx} )")
        print(f"pay = exp( {-(x-mean)**2} / {2 * var} )")
        print(f"pay = {numerator}")
        print()

        print(f"payda =  sqrt(2 * pi * v_{idx})")
        print(f"payda =  sqrt({2 * np.pi * var})")
        print(f"payda = {denominator}")
        print()

        result = numerator / denominator
        print(f"P(x|{idx}) = {result}")

        return result


if __name__ == "__main__":
    np.set_printoptions(precision=3, suppress=True, threshold=sys.maxsize)

    X = np.array([
        [10,  1,  0],
        [ 4,  4,  2],
        [ 4, -2,  4],
        [ 2,  3,  4],
        [ 1, -3,  3],
        [-2,  8,  1],
        [-3,  3,  3],
        [-4,  0, -4],
    ])
    # y mutlaka 0'dan başlamalı ve ardışık olarak artmalı
    y = np.array([
        1,
        1,
        0,
        1,
        0,
        1,
        0,
        0,
    ])
    test = np.array([2, -3, 4])

    nb = NaiveBayes()
    nb.fit(X, y)
    nb.predict(test)
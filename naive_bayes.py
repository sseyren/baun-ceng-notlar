# Based on https://github.com/python-engineer/MLfromscratch/blob/master/mlfromscratch/naivebayes.py
# Thanks to https://github.com/python-engineer

import os
import numpy as np

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
        print(self._mean)
        print()
        print("Varyans matrisi:")
        print(self._var)
        print()
        print("Her sınıf için önsel olasılık:")
        print(self._priors)
        print(os.linesep)

    def predict(self, X):
        y_pred = [self._predict(x) for x in X]
        return np.array(y_pred)

    def _predict(self, x):
        posteriors = []

        # calculate posterior probability for each class
        for idx, c in enumerate(self._classes):
            print(f"{c} sınıfı için:")

            prior = np.log(self._priors[idx])
            print(f"{self._priors[idx]} önsel olasılığın log'u: {prior}")
            print()

            pdf = self._pdf(idx, x)
            print(f"P({x} | {idx}) = {pdf}")

            pdf_log = np.log(pdf)
            print(f"Bu vektörün log'u: {pdf_log}")

            posterior = np.sum(pdf_log)
            print(f"Vektör bileşenlerin toplamı: {posterior}")
            print()

            posterior = prior + posterior
            print(f"Önsel olasılık ile toplamı: {posterior}")
            print("Bu sınıf için olasılık sonucuna ulaşıldı.")
            print(os.linesep)

            posteriors.append(posterior)

        print(f"Tüm sınıflar için olasılıklar: {posteriors}")

        # return class with highest posterior probability
        result = self._classes[np.argmax(posteriors)]
        print(f"En yüksek olasılık {result} sınıfında mevcut")
        print(os.linesep)

        return result

    def _pdf(self, class_idx, x):
        mean = self._mean[class_idx]
        var = self._var[class_idx]
        numerator = np.exp(- (x-mean)**2 / (2 * var))
        denominator = np.sqrt(2 * np.pi * var)
        return numerator / denominator


if __name__ == "__main__":
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
    test = np.array([
        [2, -3, 4],
    ])

    nb = NaiveBayes()
    nb.fit(X, y)
    predictions = nb.predict(test)

    print(f"Bu modele göre sonuçlar:")
    print(predictions)
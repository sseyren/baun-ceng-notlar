import numpy as np

def euclidean_distance(first:np.ndarray, second:np.ndarray):
    return np.sqrt(np.sum((first-second)**2))
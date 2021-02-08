import numpy as np

def euclidean_distance(first:np.ndarray, second:np.ndarray):
    return np.sqrt(np.sum((first-second)**2))

def manhattan_distance(first:np.ndarray, second:np.ndarray):
    return np.sum(np.abs(first-second))


def print_arr(arr, row_prefix="x", col_prefix="x", header=True, label="", num_start=1):
    _, n_col = arr.shape

    if header:
        header_str = ("{:<8}" * n_col).format(*(f"{col_prefix}_{i}" for i in range(num_start, n_col + num_start)))
        print(f"{label:<8}{header_str}")

    row_str = "{:<8}" + ("{:<8.3f}" * n_col)
    for row_i, row in enumerate(arr, num_start):
        elements = [f"{row_prefix}_{row_i}"] + [i for i in row]
        print(row_str.format(*elements))
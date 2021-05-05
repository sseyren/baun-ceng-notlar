"""
Feedback Shift Register
Geri-Beslemeli Kayfırmalı Yazdırgaç
"""

def state_str(state:list):
    return "".join(str(int(x)) for x in state)

class BaseFSR:
    def _preprocess(self, input):
        return input if type(input) == bool else bool(int(input))

    def _preprocess_list(self, input:list):
        return list(map(self._preprocess, input))

    def __init__(self, initial_state=[]):
        self.state = self._preprocess_list(initial_state)

    def __str__(self):
        return f"<{self.__class__.__name__} {state_str(self.state)}>"

    def shift(self, value:bool):
        pvalue = self._preprocess(value)
        self.state.insert(0, pvalue)
        return self.state.pop()

    def f(self):
        "Override this."
        pass

class FSR1(BaseFSR):
    "Örnek 5.3.1"

    def f(self):
        x = self.state
        return bool((x[0]) ^ (x[1] * x[2]) ^ (x[3] * x[4]) )

class FSR2(BaseFSR):
    "Örnek 5.3.3"

    def f(self):
        x = self.state
        return bool(x[0] ^ x[2])


def is_periodic(fsr:BaseFSR, max_iter=20) -> int:
    start_state = fsr.state.copy()
    stack = []
    print(f"t0: {fsr}")

    for i in range(1, max_iter+1):
        t = fsr.f()
        #stack.append(t)
        stack.append(fsr.shift(t))
        print(f"t{i}: {fsr}")

        if start_state == fsr.state:
            print(f"z: ({state_str(stack)})^∞")
            return i

    return -1


if __name__ == "__main__":
    fsr1 = FSR1("01011")
    print(is_periodic(fsr1))
    print()

    fsr2 = FSR2("101")
    print(is_periodic(fsr2))
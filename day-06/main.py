def read_input():
    with open('./day-06/input/input.txt') as f:
        return f.read()


def is_unique_occurrences(x): return len(set(x)) == len(x)


def step_1():
    input = list(read_input())
    for i in range(4, len(input)):
        if is_unique_occurrences(input[i-4:i]):
            return i


def step_2():
    input = list(read_input())
    for i in range(14, len(input)):
        if is_unique_occurrences(input[i-14:i]):
            return i


print('Step 1', step_1(), sep=': ')  # 1155
print('Step 2', step_2(), sep=': ')  # 2789

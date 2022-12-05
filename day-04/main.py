
import re


def read_input():
    with open('./day-04/input/input.txt') as f:
        return f.readlines()


def parse_input(lines: 'list[str]') -> 'list[list[int]]':
    return [list(map(int, re.findall(r'\d+', pairs))) for pairs in lines]


def step_1():
    text = read_input()
    pairs = parse_input(text)
    double_work_counter = 0

    for a, b, c, d in pairs:
        if a in set(range(c, d)) and b in set(range(c, d)) or c in set(range(a, b)) and d in set(range(a, b)):
            double_work_counter += 1

    print(double_work_counter)


step_1()

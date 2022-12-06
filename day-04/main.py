
import re


def read_input():
    with open('./day-04/input/input.txt') as f:
        return f.readlines()


def parse_input(lines: 'list[str]') -> 'list[list[int]]':
    return [list(map(int, re.findall(r'\d+', pairs))) for pairs in lines]


def irange(a: int, b: int) -> 'range':
    return range(a, b + 1)


def step_1() -> int:
    text = read_input()
    pairs = parse_input(text)
    result = 0

    for a, b, c, d in pairs:
        set_one = set(irange(a, b))
        set_two = set(irange(c, d))
        # find the difference between the sets
        if len(set_one - set_two) == 0 or len(set_two - set_one) == 0:
            result += 1

    return result


def step_2() -> int:
    text = read_input()
    pairs = parse_input(text)
    result = 0

    for a, b, c, d in pairs:
        set_one = set(irange(a, b))
        set_two = set(irange(c, d))
        # find the intersection between the sets
        if len(set_one & set_two) > 0:
            result += 1

    return result


print('Step 1', step_1(), sep=': ')
print('Step 2', step_2(), sep=': ')

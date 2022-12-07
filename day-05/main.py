from typing import Tuple
import re


def read_input():
    with open('./day-05/input/input.txt') as f:
        return f.readlines()


def parse_input(lines: 'list[str]') -> Tuple['list[list[int]]', 'list[list[str]]']:
    stack_lines = lines[7::-1]
    stack = [[] for _ in range(9)]

    for line in stack_lines:
        for i, idx in enumerate(range(1, len(line), 4)):
            if line[idx] != ' ':
                stack[i].append(line[idx])

    instructions = [map(int, re.findall(r'\d+', line)) for line in lines[10:]]

    return instructions, stack


def reorder_stack(instructions: 'list[list[int]]', stack: 'list[list[str]]') -> 'list[list[str]]':
    ordered_stack = stack[::]
    for amount, origin, destination in instructions:
        to_be_moved = ordered_stack[origin-1][-amount:]
        ordered_stack[origin-1] = ordered_stack[origin-1][:len(ordered_stack[origin-1])-amount]
        ordered_stack[destination-1] = ordered_stack[destination-1] + to_be_moved[::-1]
    return ordered_stack


def step_1() -> int:
    input = read_input()
    instructions, stack = parse_input(input)
    ordered_stack = reorder_stack(instructions, stack)

    last_crates = [stack[-1][-1] for stack in ordered_stack]

    return ''.join(last_crates)


print('Step 1', step_1(), sep=': ')

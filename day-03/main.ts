import { getInput } from "./input/input.ts";

const input = await getInput();

const lowerCaseAsciiOffset = -96;
const upperCaseAsciiOffset = -38;

const sliceInHalf = (list: string[]): [string[], string[]] => {
  const half = Math.ceil(list.length / 2);
  return [list.slice(0, half), list.slice(half)];
};

const intersection = (listA: string[], listB: string[]) =>
  listA.filter((x) => listB.includes(x))[0];

const isUpperCase = (char: string) => char === char.toUpperCase();

const toPriority = (char: string) => {
  if (isUpperCase(char)) {
    return char.charCodeAt(0) + upperCaseAsciiOffset;
  }

  return char.charCodeAt(0) + lowerCaseAsciiOffset;
};

const result = input
  .split(/\n/g)
  .map((s) => s.split(""))
  .map(sliceInHalf)
  .map((halfs) => intersection(halfs[0], halfs[1]))
  .map(toPriority)
  .reduce((memo, current) => memo + current, 0);

console.log(result);

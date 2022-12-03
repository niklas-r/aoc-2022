import { getInput } from "./input/input.ts";

const input = await getInput();

const lowerCaseAsciiOffset = -96;
const upperCaseAsciiOffset = -38;

const groupByN = (n: number, data: string[][]) => {
  const result = [];
  for (let i = 0; i < data.length; i += n) result.push(data.slice(i, i + n));
  return result;
};

const isUpperCase = (char: string) => char === char.toUpperCase();

const toPriority = (char: string) => {
  if (isUpperCase(char)) {
    return char.charCodeAt(0) + upperCaseAsciiOffset;
  }

  return char.charCodeAt(0) + lowerCaseAsciiOffset;
};

const rows = input
  .split(/\n/g)
  .map((s) => s.split(""));

const groupsOfThree = groupByN(3, rows);

const result = groupsOfThree
  .map((group) =>
    [...new Set(group.reduce((a, b) => a.filter((c) => b.includes(c))))][0]
  )
  .map(toPriority)
  .reduce((memo, current) => memo + current, 0);

console.log(result);

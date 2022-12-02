import { getInput } from "./input/input.ts";

const input = await getInput();

const listOfCalories = input
  .split(/\n\n/g)
  .map((chunkStr) =>
    chunkStr.split(/\n/g).map((calorie) => parseInt(calorie, 10))
  );

const sumCalories = (calories: number[]) =>
  calories.reduce((memo, current) => memo + current, 0);

const summedCalories = listOfCalories.map((calories, index) => ({
  calories: sumCalories(calories),
  index: index + 1,
}));

const sorted = summedCalories.sort((a, b) => b.calories - a.calories);
console.log(sorted[0].calories + sorted[1].calories + sorted[2].calories);

export const getSample = async (): Promise<string> => {
  return await Deno.readTextFile("input/sample.txt");
};

export const getInput = async (): Promise<string> => {
  return await Deno.readTextFile("day-03/input/input.txt");
};

namespace day_02;

class Program
{
    public static void Main()
    {
        var inputParser = new InputParser("../../../input/input.txt");
        var rounds = inputParser.GetRounds();
        var score = rounds
            .Select(round => round.Play())
            .Select(result => result.GetScore())
            .Sum();
        Console.WriteLine(score);
    }
}
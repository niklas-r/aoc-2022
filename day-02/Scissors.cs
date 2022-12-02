namespace day_02;

class Scissors : IChoice
{
    public bool Beats(IChoice choice)
    {
        return choice switch
        {
            Paper => true,
            Rock => false,
            Scissors => false,
            _ => throw new ArgumentException()
        };
    }

    public int GetScore()
    {
        return 3;
    }
}
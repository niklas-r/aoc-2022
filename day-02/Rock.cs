namespace day_02;

class Rock : IChoice
{
    public bool Beats(IChoice choice)
    {
        return choice switch
        {
            Paper => false,
            Rock => false,
            Scissors => true,
            _ => throw new ArgumentException()
        };
    }

    public int GetScore()
    {
        return 1;
    }
}
namespace day_02;

class Paper : IChoice
{
    public bool Beats(IChoice choice)
    {
        return choice switch
        {
            Paper => false,
            Rock => true,
            Scissors => false,
            _ => throw new ArgumentException()
        };
    }

    public int GetScore()
    {
        return 2;
    }
}
namespace day_02;

public class RoundResult
{
    public RoundResult(WinningPlayer winner, IChoice choicePlayerOne, IChoice choicePlayerTwo)
    {
        Winner = winner;
        ChoicePlayerOne = choicePlayerOne;
        ChoicePlayerTwo = choicePlayerTwo;
    }

    public WinningPlayer Winner { get; set; }
    public IChoice ChoicePlayerOne { get; set; }
    public IChoice ChoicePlayerTwo { get; set; }
    
    private int GetDefaultMatchScore()
    {
        return Winner switch
        {
            WinningPlayer.DRAW => 3,
            WinningPlayer.ONE => 0,
            WinningPlayer.TWO => 6,
            _ => throw new Exception("Couldn't determine winning score")
        };
    }

    public int GetScore()
    {
        return ChoicePlayerTwo.GetScore() + GetDefaultMatchScore();
    }
}
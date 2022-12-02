namespace day_02;

public class Round
{
    private readonly char _inputPlayerOne;
    private readonly char _inputPlayerTwo;

    public Round(char inputPlayerOne, char inputPlayerTwo)
    {
        _inputPlayerOne = inputPlayerOne;
        _inputPlayerTwo = inputPlayerTwo;
    }

    public RoundResult Play()
    {
        var choiceFactory = new ChoiceFactory();
        var (playerOne, playerTwo) = choiceFactory.CreateChoice(_inputPlayerOne, _inputPlayerTwo);

        if (playerOne.Beats(playerTwo))
        {
            return new RoundResult(
                WinningPlayer.ONE,
                playerOne,
                playerTwo);
        }

        if (playerTwo.Beats(playerOne))
        {
            return new RoundResult(
                WinningPlayer.TWO,
                playerOne,
                playerTwo);
        }

        return new RoundResult(
            WinningPlayer.DRAW,
            playerOne,
            playerTwo);
    }
}
namespace day_02;

class ChoiceFactory
{
    private readonly Dictionary<char, Func<IChoice>> _playerOneChoices = new()
    {
        { 'A', () => new Rock() },
        { 'B', () => new Paper() },
        { 'C', () => new Scissors() }
    };

    private readonly Dictionary<char, Func<IChoice, IChoice>> _playerTwoChoices = new()
    {
        // Need to lose
        { 'X', (IChoice playerOneChoice) =>
            {
                
                return playerOneChoice switch
                {
                    Paper paper => new Rock(),
                    Rock rock => new Scissors(),
                    Scissors scissors => new Paper(),
                    _ => throw new ArgumentOutOfRangeException(nameof(playerOneChoice))
                };
            }
        },
        // Need to Draw
        { 'Y', (IChoice playerOneChoice) => playerOneChoice },
        // Need to win
        { 'Z', (IChoice playerOneChoice) =>
        {
            return playerOneChoice switch
            {
                Paper paper => new Scissors(),
                Rock rock => new Paper(),
                Scissors scissors => new Rock(),
                _ => throw new ArgumentOutOfRangeException(nameof(playerOneChoice))
            };
        } }
    };

    public (IChoice, IChoice) CreateChoice(char inputPlayerOne, char inputPlayerTwo)
    {
        Func<IChoice>? playerOneChoiceFn = null;
        Func<IChoice, IChoice>? playerTwoChoiceFn = null;
        
        if (_playerOneChoices.ContainsKey(inputPlayerOne))
        {
            playerOneChoiceFn = _playerOneChoices.GetValueOrDefault(inputPlayerOne);
        }
        else
        {
            throw new ArgumentException("Input " + inputPlayerOne + " does not match with a choice for player one");
        }
        
        if (_playerTwoChoices.ContainsKey(inputPlayerTwo))
        {
            playerTwoChoiceFn = _playerTwoChoices.GetValueOrDefault(inputPlayerTwo);
        }
        else
        {
            throw new ArgumentException("Input " + inputPlayerTwo + " does not match with a choice for player two");
        }

        if (playerOneChoiceFn == null || playerTwoChoiceFn == null)
        {
            throw new Exception("Couldn't create all player choices");
        }
        return (playerOneChoiceFn(), playerTwoChoiceFn(playerOneChoiceFn()));
    }
}
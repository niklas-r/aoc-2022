namespace day_02;

public class InputParser
{
    private IEnumerable<string> Input { get; set; }
    public InputParser(string filePath)
    {
        Input = File.ReadAllLines(filePath);
    }

    public IEnumerable<Round> GetRounds()
    {
        return Input.Select(s =>
        {
            var choices = s.Replace(" ", "").ToCharArray();
            return new Round(choices[0], choices[1]);
        });
    }
}
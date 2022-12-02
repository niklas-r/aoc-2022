namespace day_02;

public interface IChoice
{
    public abstract bool Beats(IChoice choice);
    public abstract int GetScore();
}
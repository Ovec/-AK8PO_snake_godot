namespace Snake.game;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Set(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool IsCollission(Position source, Position target)
    {
        return (source.X == target.X && source.Y == target.Y);
    }
}
using Snake.game.Interfaces;

namespace Snake.game;

public class Berry : Renderable, Treat
{
    private Random random = new Random();
    public Position Position { get; set; }
    private ConsoleColor Color { get; }
    private int Value { get; }

    public Berry(Position position, ConsoleColor color, int value = 1)
    {
        Position = position;
        Color = color;
        Value = value;
    }

    public List<Position> GetPositions()
    {
        return new(){Position};
    }

    public ConsoleColor GetColor()
    {
        return Color;
    }

    public int GetValue()
    {
        return Value;
    }

    public void Move(Position[] fence)
    {
        Position = new Position(random.Next(fence[0].X + 1, fence[1].X - 1), random.Next(fence[0].Y + 1, fence[1].Y - 1));
    }
}
namespace Snake.game;

public class SnakeBody : Renderable
{
    public List<Position> Positions = new ();

    private ConsoleColor Color;

    public SnakeBody(ConsoleColor color)
    {
        Color = color;
    }

    public void AddToBody(Position position)
    {
        Positions.Add(position);
    }

    public void RemoveFirstFromBody()
    {
        Positions.RemoveAt(0);
    }

    public ConsoleColor GetColor()
    {
        return Color;
    }

    public List<Position> GetPositions()
    {
        return Positions;
    }
}
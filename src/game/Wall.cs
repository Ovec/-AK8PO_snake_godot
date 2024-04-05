namespace Snake.game;

public class Wall : Renderable
{
    private int Length;
    private Orientation Orientation;
    private ConsoleColor Color;
    private Position StartPosition;
    private List<Position> Positions = new();

    public Wall(int length, Orientation orientation, ConsoleColor color, Position startPosition)
    {
        Length = length;
        Orientation = orientation;
        Color = color;
        StartPosition = startPosition;
        BuildWall();
    }

    private void BuildWall()
    {
        if (Orientation == Orientation.Horizontal) BuildHorizontalWall();
        if (Orientation == Orientation.Vertical) BuildVerticalWall();
    }

    private void BuildHorizontalWall()
    {
        for (int i = 1; i < Length; i++)
        {
            Positions.Add(new Position(StartPosition.X + i, StartPosition.Y));
        }
    }

    private void BuildVerticalWall()
    {
        for (int i = 1; i < Length; i++)
        {
            Positions.Add(new Position(StartPosition.X, StartPosition.Y + i));
        }
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


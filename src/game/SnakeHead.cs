using Snake.inputs;

namespace Snake.game;

public class SnakeHead : Renderable
{

    public Position Position { get; set; }
    private ConsoleColor Color;


    public SnakeHead(Position position, ConsoleColor color)
    {
        Position = position;
        Color = color;
    }

    public ConsoleColor GetColor()
    {
        return Color;
    }

    public List<Position> GetPositions()
    {
        return new() { Position };
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveUp();
                break;
            case Direction.Down:
                MoveDown();
                break;
            case Direction.Left:
                MoveLeft();
                break;
            case Direction.Right:
                MoveRight();
                break;
            case Direction.Stop:
                System.Threading.Thread.Sleep(1000000);
                break;

        }
    }

    private void MoveUp()
    {
        Position.Y--;
    }

    private void MoveDown()
    {
        Position.Y++;
    }

    private void MoveRight()
    {
        Position.X++;
    }

    private void MoveLeft()
    {
        Position.X--;
    }

}
namespace Snake.game;

public interface Renderable
{
    public List<Position> GetPositions();
    public ConsoleColor GetColor();
}
using Snake.game;
using static System.Console;

namespace Snake.outputs;
public class Pixel
{
    private Position Position { get; }
    private ConsoleColor ConsoleColor { get; }

    public Pixel(Position position, ConsoleColor consoleColor)
    {
        Position = position;
        ConsoleColor = consoleColor;
    }

    public void Draw ()
    {
        SetCursorPosition (Position.X, Position.Y);
        ForegroundColor = ConsoleColor;
        Write ("■");
        SetCursorPosition (0, 0);
    }
}
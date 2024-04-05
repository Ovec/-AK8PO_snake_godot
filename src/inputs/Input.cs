using System.Diagnostics;
using static System.Console;
namespace Snake.inputs;


public class Input
{
    public Direction CurrentMovement { get; private set; } = Direction.Right;

    public static void ReadKeyboardKey()
    {
        ReadKey();
    }

    public Direction GetMovement()
    {
        var sw = Stopwatch.StartNew();
        while (sw.ElapsedMilliseconds <= 300)
        {

            ReadMovement();
        }
        return CurrentMovement;
    }

    private void ReadMovement()
    {
        if (KeyAvailable)
        {
            var key = ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && CurrentMovement != Direction.Down)
            {
                CurrentMovement = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow && CurrentMovement != Direction.Up)
            {
                CurrentMovement = Direction.Down;
            }
            else if (key == ConsoleKey.LeftArrow && CurrentMovement != Direction.Right)
            {
                CurrentMovement = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow && CurrentMovement != Direction.Left)
            {
                CurrentMovement = Direction.Right;
            }

        }
    }
}
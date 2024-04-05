namespace Snake.game;

public class Player
{
    public SnakeHead Head;
    public SnakeBody Body;
    public Player()
    {
        Head = new SnakeHead(new Position(Config.GameWidth / 2, Config.GameHeight / 2), ConsoleColor.Red);
        Body = new SnakeBody(ConsoleColor.Green);
    }
}
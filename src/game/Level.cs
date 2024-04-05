namespace Snake.game;

public class Level
{
    public List<Wall> Walls;
    public readonly List<Berry> Treats;

    public Level()
    {
        var rand = new Random();

        var berry1 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.Magenta);
        var berry2 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.DarkYellow);
        var berry3 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.Gray);
        var berry4 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.Gray);
        var berry5 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.Gray);
        var berry6 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.Gray);
        var berry7 = new Berry(new Position(rand.Next(1, Config.GameWidth - 2), rand.Next(2, Config.GameHeight - 2)), ConsoleColor.Gray);

        var topWall = new Wall(Config.GameWidth+1, Orientation.Horizontal, ConsoleColor.Yellow, new Position(-1, 1));
        var bottomWall = new Wall(Config.GameWidth, Orientation.Horizontal, ConsoleColor.Yellow, new Position(0, Config.GameHeight));
        var leftWall = new Wall(Config.GameHeight, Orientation.Vertical, ConsoleColor.Yellow, new Position(0, 1));
        var rightWall = new Wall(Config.GameHeight, Orientation.Vertical, ConsoleColor.Yellow, new Position(Config.GameWidth -1, 1));

        Walls = new List<Wall>() { topWall, bottomWall, leftWall, rightWall};
        Treats = new List<Berry>() { berry1, berry2, berry3, berry4, berry5, berry6, berry7 };
    }
}
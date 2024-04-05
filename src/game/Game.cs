using Snake.game.Interfaces;
using Snake.inputs;

namespace Snake.game;

public class Game
{
    public List<Wall> Walls { get; }
    public List<Berry> Treats { get; }
    public SnakeHead SnakeHead { get; }
    public SnakeBody SnakeBody { get; }
    public bool IsGameOver { get; private set; } = false;
    public int Score { get; private set; }
    private Direction CurentMovement;
    private Position[] Fence = new Position[2];

    public Game(Level level, Player player, int score, Direction currentMovement)
    {
        Walls = level.Walls;
        Treats = level.Treats;
        SnakeHead = player.Head;
        SnakeBody = player.Body;
        Score = score;
        CurentMovement = currentMovement;
        CreateFence();
    }

    public void Play(Direction movement)
    {
        CurentMovement = movement;
        SnakeBody.AddToBody(new Position(SnakeHead.Position.X, SnakeHead.Position.Y));
        SnakeHead.Move(CurentMovement);
        IsCollisionWithWallOrBody();
        IsCollisionWithTreats();
    }

    public void IsCollisionWithWallOrBody()
    {
        if (IsHeadCollisionWithMany(Walls.Cast<Renderable>().ToList(), SnakeHead.Position)) IsGameOver = true;
        if (IsCollisionWithOne(SnakeBody, SnakeHead.Position)) IsGameOver = true;
    }

    public void IsCollisionWithTreats()
    {
        foreach (var treat in Treats)
        {
            var positions = treat.GetPositions();
            foreach (var position in positions)
            {
                if (Position.IsCollission(position, SnakeHead.Position))
                {
                    Score += treat.GetValue();
                    treat.Move(Fence);
                }
            }
        }
    }

    private static bool IsCollisionWithOne(Renderable item, Position position)
    {
        foreach (var pos in item.GetPositions())
        {
            if (Position.IsCollission(pos, position)) return true;
        }
        return false;
    }

    private bool IsHeadCollisionWithMany(List<Renderable> items, Position position)
    {
        foreach (var pos in GetPositions(items))
        {
            if (Position.IsCollission(pos, position)) return true;
        }
        return false;
    }

    private static List<Position> GetPositions(List<Renderable> items)
    {
        var positions = new List<Position>(){};
        foreach (var item in items)
        {
            positions.AddRange(item.GetPositions());
        }
        return positions;
    }

    private void CreateFence()
    {
        int minX = Int32.MaxValue;
        int minY = Int32.MaxValue;
        int maxX = Int32.MinValue;
        int maxY = Int32.MinValue;

        foreach (var wall in GetPositions(Walls.Cast<Renderable>().ToList()))
        {
            if (wall.X < minX) minX = wall.X;
            if (wall.Y < minY) minY = wall.Y;
            if (wall.X > maxX) maxX = wall.X;
            if (wall.Y > maxY) maxY = wall.Y;
        }

        Fence[0] = new Position(minX, minY);
        Fence[1] = new Position(maxX, maxY);
    }
}
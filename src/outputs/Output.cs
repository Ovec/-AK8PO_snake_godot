using Snake.game;
using static System.Console;

namespace Snake.outputs;

public class Output
{
    private Game game;

    public Output(Game game)
    {
        this.game = game;
    }

    public void Render()
    {
        Clear();
        if (!game.IsGameOver)
        {
            WriteLine($"Score: {game.Score - 5}");
        } else {
            BackgroundColor = ConsoleColor.DarkRed;
            WriteLine($"Score: {game.Score - 5} GAME OVER");
            ResetColor();
        }
        RenderGame();
    }

    private void RenderGame()
    {
        RenderWalls();
        RenderSnake();
        RenderTreats();
    }

    private void RenderSnake()
    {
        RenderRenderable(game.SnakeHead);
        RenderRenderable(game.SnakeBody);
        if (game.SnakeBody.Positions.Count > game.Score)
        {
            game.SnakeBody.RemoveFirstFromBody();
        }
    }

    private void RenderTreats()
    {
        foreach (var renderable in game.Treats)
        {
            RenderRenderable(renderable);
        }
    }

    private void RenderWalls()
    {
        foreach (var renderable in game.Walls)
        {
            RenderRenderable(renderable);
        }
    }

    private void RenderRenderable(Renderable item)
    {
        var positions = item.GetPositions();
        var color = item.GetColor();
        foreach (var postion in positions)
        {
            new Pixel(postion, color).Draw();
        }
    }
}
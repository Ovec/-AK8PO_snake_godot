using Snake.game;
using Snake.outputs;
using Snake.inputs;
namespace SnakeGodot
{
    class Program
    {
        static void Main ()
        {
            var design = new Level();
            var player = new Player();

            var input = new Input();
            var game = new Game(design, player, Config.InitialScore, input.GetMovement());
            var output = new Output(game);

            while (true)
            {
                var currentMovement = game.IsGameOver ? Direction.Stop : input.GetMovement();
                game.Play(currentMovement);
                output.Render();
            }
        }
    }
}
namespace Snake.game.Interfaces;

public interface Treat
{
    public int GetValue();

    public void Move(Position[] fence);
}
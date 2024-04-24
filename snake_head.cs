using Godot;
using System;

public partial class snake_head : CharacterBody2D
{
	public const float Speed = 300.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		velocity.X = direction.X * Speed;
		velocity.Y = direction.Y * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}

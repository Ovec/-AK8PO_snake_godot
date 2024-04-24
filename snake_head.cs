using Godot;
using System;

public partial class snake_head : CharacterBody2D
{
	public const float Speed = 300.0f;

	// Track the previous direction
	private Vector2 previousDirection = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 currentDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		if (currentDirection != previousDirection && currentDirection.Length() > 0.0f) 
		{
			// Calculate the angle in radians
			float angle = currentDirection.Angle();

			// Convert radians to degrees for easier use with rotation
			float angleInDegrees = Mathf.RadToDeg(angle);

			// Apply the rotation to the snake's head
			RotationDegrees = angleInDegrees;

			previousDirection = currentDirection; 
		}

		// Update the velocity based on the current direction
		velocity.X = currentDirection.X * Speed;
		velocity.Y = currentDirection.Y * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}


using Godot;
using System;

public partial class snake_head : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float ScreenWidth = 1200.0f; // Define the screen width
	public const float ScreenHeight = 1200.0f; // Define the screen height
	public const float step = 1.0f;

	// Track the previous direction
	private Vector2 previousDirection = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 currentDirection = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		// Update the velocity based on the current direction
		velocity.X = currentDirection.X * Speed * step;
		velocity.Y = currentDirection.Y * Speed * step;

		Velocity = velocity;
		MoveAndSlide();

		// Get the current global position
		Vector2 currentPosition = GlobalPosition;

		// Check if the snake head reaches the left or right edge and wrap around
		if (currentPosition.X < 0) // Left edge
		{
			GlobalPosition = new Vector2(ScreenWidth, currentPosition.Y);
		}

		if (currentPosition.Y < 0)
		{
			GlobalPosition = new Vector2(currentPosition.X, ScreenHeight);
		}

		if (currentPosition.X > ScreenWidth) // Right edge
		{
			GlobalPosition = new Vector2(0, currentPosition.Y);
		}

		if (currentPosition.Y > ScreenHeight)
		{
			GlobalPosition = new Vector2(currentPosition.X, 0);
		}

		// head rotation
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
	}
}

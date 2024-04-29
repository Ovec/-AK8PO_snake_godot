using Godot;
using System;

public partial class snake_head : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float ScreenWidth = 1200.0f; // Define the screen width
	public const float ScreenHeight = 1200.0f; // Define the screen height
	public const float step = 5.0f;
	private Vector2 currentDirection = new Vector2(1, 0); // Initial direction to the right

	// Track the previous direction
	private Vector2 previousDirection = Vector2.Zero;

	public override void _Process(double delta)
	{
		HandleDirectionChange(); // Check for key presses to change direction
	}

	public void move()
	{
		Vector2 velocity = Velocity;

		// Update the velocity based on the current direction
		velocity.X = currentDirection.X * Speed * step;
		velocity.Y = currentDirection.Y * Speed * step;

		Velocity = velocity;
		MoveAndSlide();

		// Handle screen wrapping
		HandleScreenWrapping();

		// Handle head rotation if the direction changes
		RotateHeadIfDirectionChanged();
	}

	private void HandleDirectionChange()
	{
		// Change direction based on key strokes, ensuring it doesn't reverse
		if (Input.IsActionJustPressed("move_up") && currentDirection != new Vector2(0, 1))
		{
			currentDirection = new Vector2(0, -1); // Move up
		}
		else if (Input.IsActionJustPressed("move_down") && currentDirection != new Vector2(0, -1))
		{
			currentDirection = new Vector2(0, 1); // Move down
		}
		else if (Input.IsActionJustPressed("move_left") && currentDirection != new Vector2(1, 0))
		{
			currentDirection = new Vector2(-1, 0); // Move left
		}
		else if (Input.IsActionJustPressed("move_right") && currentDirection != new Vector2(-1, 0))
		{
			currentDirection = new Vector2(1, 0); // Move right
		}
	}

	private void HandleScreenWrapping()
	{
		// Get the current global position
		Vector2 currentPosition = GlobalPosition;

		// Wrap around if the snake head reaches the boundary
		if (currentPosition.X < 0) // Left edge
		{
			GlobalPosition = new Vector2(ScreenWidth, currentPosition.Y);
		}
		else if (currentPosition.X > ScreenWidth) // Right edge
		{
			GlobalPosition = new Vector2(0, currentPosition.Y);
		}

		if (currentPosition.Y < 0) // Top edge
		{
			GlobalPosition = new Vector2(currentPosition.X, ScreenHeight);
		}
		else if (currentPosition.Y > ScreenHeight) // Bottom edge
		{
			GlobalPosition = new Vector2(currentPosition.X, 0);
		}
	}

	private void RotateHeadIfDirectionChanged()
	{
		if (currentDirection != previousDirection && currentDirection.Length() > 0.0f)
		{
			// Calculate the angle in radians
			float angle = currentDirection.Angle();

			// Convert radians to degrees
			float angleInDegrees = Mathf.RadToDeg(angle);

			// Apply the rotation to the snake's head
			RotationDegrees = angleInDegrees;

			previousDirection = currentDirection; // Update the previous direction
		}
	}

	private void _on_timer_timeout()
	{
		move(); // Move the snake at regular intervals
	}
}

using Godot;
using presenter;
using System;

public partial class GodotPlayerView : CharacterBody2D, PlayerView
{
	public event Action<PlayerView.Input> OnInput;
	private const float Speed = 200.0f;
	private const float AnimationSpeed = 5f;
	private AnimatedSprite2D animation;
	private string currentDirection;
	private Vector2 velocity;

	public override void _Ready()
	{
		this.animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		this.Turn(PlayerView.Direction.FRONT);
		this.Stop();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_shift"))
		{
			OnInput?.Invoke(PlayerView.Input.RUN);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("ui_right"))
		{
			OnInput?.Invoke(PlayerView.Input.RIGHT);
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			OnInput?.Invoke(PlayerView.Input.LEFT);
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			OnInput?.Invoke(PlayerView.Input.UP);
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			OnInput?.Invoke(PlayerView.Input.DOWN);
		}
		else
		{
			OnInput?.Invoke(PlayerView.Input.NONE);
		}
	}

	public void Run(PlayerView.Direction direction)
	{
		this.Turn(direction);
		this.Move(true);
		this.animation.Play(this.currentDirection + "_Run", AnimationSpeed * 2);
	}

	public void Walk(PlayerView.Direction direction)
	{
		this.Turn(direction);
		this.Move(false);
		this.animation.Play(this.currentDirection + "_Walk", AnimationSpeed);
	}

	public void Stop()
	{
		this.velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		this.velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		Velocity = this.velocity;

		this.animation.Play(this.currentDirection + "_Idle", AnimationSpeed);
	}

	public float[] GetPosition()
	{
		var position = GlobalPosition;
		return new float[]{ position.X, position.Y };
	}

	private void Move(bool isRunning)
	{
		this.velocity = Velocity;
		var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		var speed = isRunning ? Speed * 2 : Speed;
		velocity.X = direction.X * speed;
		velocity.Y = direction.Y * speed;

		Velocity = velocity;
		MoveAndSlide();
	}

	private void Turn(PlayerView.Direction direction)
	{
		this.currentDirection = char.ToUpper(direction.ToString()[0]) + direction.ToString().Substring(1).ToLower();
	}

}

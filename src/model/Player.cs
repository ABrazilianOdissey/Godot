namespace model;

public class Player
{
	private string name;
	private bool stopped;
	private bool running;
	private Direction direction;

	public Player(string name)
	{
		this.name = name;
		this.stopped = true;
		this.direction = Direction.FRONT;
	}

	public void Walk()
	{
		this.stopped = false;
		this.running = false;
	}

	public void Run()
	{
		this.stopped = false;
		this.running = true;
	}

	public void Stop()
	{
		this.stopped = true;
		this.running = false;
	}

	public void Turn(Direction direction)
	{
		this.direction = direction;
	}

	public bool IsRunning()
	{
		return this.running;
	}

	public enum Direction
	{
		FRONT, BACK, LEFT, RIGHT
	}

}

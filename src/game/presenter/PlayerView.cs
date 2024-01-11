using System;

namespace presenter;

public interface PlayerView
{
	event Action<Input> OnInput;
	void Run(Direction direction);
	void Walk(Direction direction);
	void Stop();
	float[] GetPosition();

    public enum Input
	{
		NONE, RUN, UP, DOWN, LEFT, RIGHT
	}

	public enum Direction
	{
		IDLE, BACK, FRONT, LEFT, RIGHT
	}
}

namespace presenter;

using model;
using service;


public class PlayerPresenter
{
	private readonly CameraService cameraService;
	private readonly Player player;
	private readonly PlayerView view;
	
	public PlayerPresenter(CameraService cameraService, Player player, PlayerView view)
	{
		this.cameraService = cameraService;
		this.player = player;
		this.view = view;
	}

	public void Start()
	{
		this.view.OnInput += HandleOnInput;
	}

	public void HandleOnInput(PlayerView.Input input)
	{
		switch (input)
		{
			case PlayerView.Input.RUN:
				ToggleRunWalk();
				break;

			case PlayerView.Input.UP:
				HandleMovement(Player.Direction.BACK, PlayerView.Direction.BACK);
				break;
			case PlayerView.Input.DOWN:
				HandleMovement(Player.Direction.FRONT, PlayerView.Direction.FRONT);
				break;
			case PlayerView.Input.LEFT:
				HandleMovement(Player.Direction.LEFT, PlayerView.Direction.LEFT);
				break;
			case PlayerView.Input.RIGHT:
				HandleMovement(Player.Direction.RIGHT, PlayerView.Direction.RIGHT);
				break;
				
			case PlayerView.Input.NONE:
				player.Stop();
				view.Stop();
				break;
		}
	}

	private void ToggleRunWalk()
	{
		if (this.player.IsRunning())
		{
			this.player.Walk();
		}
		else
		{
			this.player.Run();
		}
	}

	private void HandleMovement(Player.Direction playerDirection, PlayerView.Direction viewDirection)
	{
		this.player.Turn(playerDirection);
		if (this.player.IsRunning())
		{
			this.view.Run(viewDirection);
		}
		else
		{
			this.view.Walk(viewDirection);
		}
		var position = this.view.GetPosition();
		this.cameraService.UpdatePosition(position[0], position[1]);
	}

}

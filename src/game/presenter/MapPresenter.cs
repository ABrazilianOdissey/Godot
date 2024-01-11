namespace presenter;

using model;
using service;

public class MapPresenter
{
	private readonly CameraService cameraService;
	private readonly Map map;
	private readonly MapView view;

	public MapPresenter(CameraService cameraService, Map map, MapView view)
	{
		this.map = map;
		this.view = view;
		this.cameraService = cameraService;
	}

	public void Start()
	{
		HandleResize();
		this.view.OnResize += HandleResize;
	}

	private void HandleResize()
	{
		var size = this.view.GetSize();
		this.cameraService.SetLimits(size[0], size[1]);
	}

}
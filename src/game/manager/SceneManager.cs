using Godot;
using model;
using presenter;
using service;

public partial class SceneManager : Node
{
	private Player player;
	private Map scene;
	private PlayerView playerView;
    private MapView sceneView;
	private CameraService cameraService;

    public override void _Ready()
	{
		var camera = GetNode<Camera2D>("Camera");
		this.cameraService = new GodotCameraService(camera);

        this.playerView = GetNode<PlayerView>("Player");
		this.player = new Player("Leandro Vieira");
		var playerPresenter = new PlayerPresenter(this.cameraService, this.player, this.playerView);
		playerPresenter.Start();
		
        this.sceneView = GetNode<MapView>("Map");
		this.scene = new Map();
		var scenePresenter = new MapPresenter(this.cameraService, this.scene, this.sceneView);
		scenePresenter.Start();
	}
}

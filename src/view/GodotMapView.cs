using System;
using Godot;

using presenter;

public partial class GodotMapView : TileMap, MapView
{
	[Export]
    public NodePath PlayerPath { get; set; }

    public event Action OnResize;
	private Vector2 currentWindowSize, baseResolution;

	public override void _Ready()
	{
		var currentSize = GetViewport().GetVisibleRect().Size;
		this.currentWindowSize = currentSize;
		this.baseResolution = currentSize;
	}

	public override void _Process(double delta)
	{
		var currentSize = GetViewport().GetVisibleRect().Size;
        if (currentSize != this.currentWindowSize)
        {
			OnResize?.Invoke();
            this.currentWindowSize = currentSize;
        }
	}

    public float[] GetSize()
	{
		int minX = int.MaxValue;
		int minY = int.MaxValue;
		int maxX = int.MinValue;
		int maxY = int.MinValue;

		foreach (var cell in this.GetUsedCells(0))
		{
			minX = Math.Min(minX, (int) cell.X);
			minY = Math.Min(minY, (int) cell.Y);
			maxX = Math.Max(maxX, (int) cell.X);
			maxY = Math.Max(maxY, (int) cell.Y);
		}

		const int tileSize = 64; // Tile size is 64x64
		var width = (maxX - minX + 1) * tileSize;
		var height = (maxY - minY + 1) * tileSize;

		return new float[]{ width, height };
	}
}

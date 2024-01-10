using Godot;
using service;
using System;

public partial class GodotCameraService : Node, CameraService
{

    private Camera2D camera;

    public GodotCameraService(Camera2D camera)
    {
        this.camera = camera;
    }

    public void SetLimits(float LimitRight, float LimitBottom)
    {
        if (this.camera != null)
        {
            this.camera.LimitLeft = 0;
            this.camera.LimitTop = 0;
            this.camera.LimitRight = (int) LimitRight;
            this.camera.LimitBottom = (int) LimitBottom;
        }
    }

    public void UpdatePosition(float X, float Y)
    {
        if (this.camera != null)
        {
            this.camera.GlobalPosition = new Vector2(X, Y);
        }
    }

}

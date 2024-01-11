namespace service;

public interface CameraService
{
	void UpdatePosition(float X, float Y);
	void SetLimits(float LimitRight, float LimitBottom);
}
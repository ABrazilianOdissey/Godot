using System;

namespace presenter;

public interface MapView
{
    event Action OnResize;
    float[] GetSize();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShadowCaster 
{
    public Vector3 Position { get; }
    public float Size { get; }

    public Vector4 CenterSize { get; }
}

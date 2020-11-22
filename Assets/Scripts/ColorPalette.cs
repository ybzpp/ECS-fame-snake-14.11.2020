using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorPalette : ScriptableObject
{
    public Color ColorA;
    public Color ColorB;
    public Color ColorWalls;

    public Texture TextureA;
    public Texture TextureB;
    public Texture TextureWalls;
}

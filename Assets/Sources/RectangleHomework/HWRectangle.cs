using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWRectangle
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public HWRectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int GetPerimetre()
    {
        int perimetre = 2 * Width + 2 * Height;

        return perimetre;
    }

    public int GetArea()
    {
        int area = Width * Height;

        return area;
    }

}

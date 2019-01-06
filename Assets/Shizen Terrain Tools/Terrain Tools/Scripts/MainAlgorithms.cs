﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shizen
{
    /// <summary>
    /// The class that contains all of Shizen's generation algorithms
    /// </summary>
    public class MainAlgorithms
    {


        public static Texture2D GeneratedSimplexTexture(Terrain _terrain, HeightLayerProps _properties)
        {
            Texture2D _working;
            int _resolution;

            //_sizeX = _terrain.terrainData.heightmapWidth;
            //_sizeY = _terrain.terrainData.heightmapHeight;
            _resolution = 256;
            _working = new Texture2D(_resolution, _resolution, TextureFormat.RGB24, true);
            _working.name = "Heightmap Noise Texture";
            _working.wrapMode = TextureWrapMode.Clamp;
            FillTextureWithNoise(_working,_properties);

            return _working;
        }

        private static void FillTextureWithNoise(Texture2D _inputTexture,HeightLayerProps _properties)
        {
            int _resolution = _inputTexture.width;
            float _stepSize = 1f / _resolution;

            Vector3 point00 = new Vector3(-0.5f, -0.5f)+ _properties.Offset;
            Vector3 point10 = new Vector3(0.5f, -0.5f) + _properties.Offset;
            Vector3 point01 = new Vector3(-0.5f, 0.5f) + _properties.Offset;
            Vector3 point11 = new Vector3(0.5f, 0.5f) + _properties.Offset;

            Vector3 _texturePoint =new Vector2();
            float _noiseSample;
            for (int y = 0; y < _resolution; y++)
            {
                Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * _stepSize);
                Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * _stepSize);
                for (int x = 0; x < _resolution; x++)
                {
                    Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * _stepSize);
                    _noiseSample = SimplexNoise.SampleSum(point, _properties.Frequency,_properties.Amplitude,_properties.Octaves,_properties.Lacunarity,_properties.Persistance);
                  
                    _noiseSample = _noiseSample * 0.5f + 0.5f;
                    _inputTexture.SetPixel(x, y, Color.white*_noiseSample);
                }
            }
            _inputTexture.Apply();
        }


        private static int FloorFast(double x)
        {
            return x > 0 ? (int)x : (int)x - 1;
        }

        private static double DotProduct(int[] g, double x, double y)
        {
            return g[0] * x + g[1] * y;
        }


    }
}
public class PerlinPoint
{
    private double _x;
    private double _y;
    private double _z;

    public double x { get { return _x; } }
    public double y { get { return _y; } }
    public double z { get { return _y; } }

    public void SetCoordinates(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public PerlinPoint(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
    }
}
public class Vector2Int
{
    public int x;
    public int y;

    public Vector2Int(int X, int Y)
    {
        x = X;
        y = Y;
    }
    public Vector2Int()
    {

    }
}
public class Vector2Double
{
    public double x;
    public double y;

    public Vector2Double(double X, double Y)
    {
        x = X;
        y = Y;
    }
    public Vector2Double()
    {

    }
}
public class Vector3Int
{
    public int x;
    public int y;
    public int z;

    public Vector3Int(int X, int Y, int Z)
    {
        x = X;
        y = Y;
        z = Z;
    }
    public Vector3Int()
    {

    }
}
public class Vector3Double
{
    public double x;
    public double y;
    public double z;

    public Vector3Double(double X, double Y, double Z)
    {
        x = X;
        y = Y;
        z = Z;
    }
    public Vector3Double()
    {

    }
}

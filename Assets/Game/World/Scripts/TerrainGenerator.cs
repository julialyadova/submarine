using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int Depth = 20;
    public int Size = 256;
    public float Scale = 20;

    public float offsetX = 100f;
    public float offsetY = 100f;

    private Terrain _terrain;

    private void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);

        _terrain = GetComponent<Terrain>();
        _terrain.terrainData = GenerateTerrain(_terrain.terrainData);
    }

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = Size + 1;
        terrainData.size = new Vector3(Size, Depth, Size);
        terrainData.SetHeights(0, 0, GenerateHeights(Size, Size));
        return terrainData;
    }

    private float[,] GenerateHeights(int width, int length)
    {
        var heights = new float[width, length];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < length; y++)
                heights[x, y] = CalculateHeight(x, y);

        return heights;
    }

    private float CalculateHeight(float x, float y)
    {
        float xCoord = x / Size * Scale + offsetX;
        float yCoord = y / Size * Scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}

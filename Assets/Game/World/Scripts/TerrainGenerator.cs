using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int Depth = 20;
    public int Size = 256;
    public float Scale = 20;
    public float BigScale = 5;

    public RandomPrefab[] Prefabs = new RandomPrefab[0];
    public float Probability = 0.01f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    private Terrain _terrain;

    private void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);

        _terrain = GetComponent<Terrain>();
        _terrain.terrainData = GenerateTerrain(_terrain.terrainData);
        GenerateObjects(Size, Size, Probability);
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

        var height = Mathf.PerlinNoise(xCoord, yCoord);

        xCoord = x / Size * BigScale + offsetX;
        yCoord = y / Size * BigScale + offsetY;

        height -= Mathf.PerlinNoise(xCoord, yCoord);

        return height;
    }

    private void GenerateObjects(int width, int length, float probability)
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < length; y++)
                    GenerateObject(x, y);
    }

    private void GenerateObject(int x, int y)
    {
        int index = Random.Range(0, Prefabs.Length);
        if (RandomBool(Prefabs[index].Probability))
        {
            Physics.Raycast(new Vector3(x, Depth + 1, y), Vector3.down, out RaycastHit raycastHit);
            Instantiate(
                Prefabs[index].Prefab,
                new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z),
                Quaternion.identity,
                transform);        
        }
    }

    private bool RandomBool(float trueChance)
    {
        return Random.Range(0f, 1f) < trueChance;
    }

    [System.Serializable]
    public class RandomPrefab
    {
        public GameObject Prefab;
        public float Probability;
    }
}

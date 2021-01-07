using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    public GameObject[] Prefabs = new GameObject[0];
    public float Probability = 0.01f;

    private Terrain _terrain;

    private void Start()
    {
        _terrain = GetComponent<Terrain>();
        GenerateObjects(_terrain.terrainData);
    }

    private void GenerateObjects(TerrainData terrainData)
    {
        var size = 256;
        for (int x = 0; x < size; x+=10)
        {
            for (int y = 0; y < size; y += 10)
            {
                if (RandomBool(Probability))
                {
                    GameObject gameObj = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
                    gameObj.transform.SetParent(transform, false);
                    gameObj.transform.localPosition = new Vector3(x, terrainData.GetHeight(x,y), y);
                }                
            }
        }
    }

    private bool RandomBool(float trueChance)
    {
        return Random.Range(0f, 1f) < trueChance;
    }
}

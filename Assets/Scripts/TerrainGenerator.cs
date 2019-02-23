using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{


    public float riverCurvature = 1f;
    public float riverLength = 100;
    public float riverDepth = 1f;
    public float riverWidth = 1f;
    public int size = 512;
    public int depth = 20;
    public float scale = 20f;
    public float height;
    private int width;
    private int length;
    public Renderer textureRenderer;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    private void OnValidate()
    {
        width = length = size;
        //Terrain terrain = gameObject.GetComponent<Terrain>();
        //terrain.terrainData = GenerateTerrain(terrain.terrainData);
        DrawMesh(MeshGenerator.GenerateTerrainMesh(GenerateHeigths()), new Texture2D(size, size));
    }

    private void DrawMesh(MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRenderer.sharedMaterial.mainTexture = texture;
    }


    private void Start()
    {
    }

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = length + 1;
        terrainData.size = new Vector3(width, depth, length);
        terrainData.SetHeights(0, 0, GenerateHeigths());

        return terrainData;
    }

    private float[,] GenerateHeigths()
    {
        float[,] heigths = new float[width, length];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                heigths[x, y] = 0.5f + CalculateHeight(x, y) - CalculateRiverDepth(x, y) * 0.5f;
            }
        }
        return heigths;
    }

    private float CalculateHeight(int x, int y)
    {
        float xCord = (float)x / width * scale;
        float yCord = (float)y / length * scale;

        return Mathf.PerlinNoise(xCord, yCord) * height;
    }

    private float CalculateRiverDepth(int x, int y)
    {

        float curvatureOffset = Mathf.Sin((float)x / length * Mathf.Deg2Rad * riverCurvature) * riverLength;
        float value = 0;
        y += (int)curvatureOffset;
        if (y > width / 2 - riverWidth * width / 2 && y < width / 2 + riverWidth * width / 2)
        {
            int angleMultiplier = 180;
            float realRiverWidth = riverWidth * width;
            float riverProgress = (y - (1 - riverWidth) * width / 2);
            value = Mathf.Sin(angleMultiplier * (riverProgress / realRiverWidth) * Mathf.Deg2Rad) * riverDepth;
        }
        return value;
    }
}

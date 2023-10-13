using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalTileGenerator : MonoBehaviour
{
    public float tileSize = 1f;

    public GameObject oldHexPrefab;
    public GameObject hexPrefab;

    public int radius = 3;

    [SerializeField] private float xOffcet = 0.5f;
    [SerializeField] private float yOffcet = 0.5f;

    [ContextMenu("Generate Old")]
    private void GenerateHexagonOld()
    {
        GameObject content = new GameObject("Container");

        int totalTiles = (3 * radius * (radius + 1)) + 1;
        int currentTile = 0;

        for (int q = -radius; q <= radius; q++)
        {
            int r1 = Mathf.Max(-radius, -q - radius);
            int r2 = Mathf.Min(radius, -q + radius);

            for (int r = r1; r <= r2; r++)
            {
                float xPos = tileSize * Mathf.Sqrt(3f) * (q + 0.5f * r);
                float zPos = tileSize * 1.5f * r;

                Vector3 position = new Vector3(xPos, 0f, zPos);
                CreateHexagon(position, content.transform, $"", false);
                currentTile++;
            }
        }
    }

    public int currentLayer;

    [ContextMenu("Generate New")]
    private void GenerateHexagon()
    {
        GameObject content = new GameObject("Container");

        //  q - line
        //  r1 - left border
        //  r2 - right border

        for (int rad = 1; rad <= radius; rad++)
        {
            CreateCircle(rad, content.transform);
        }

        CreateCircle(currentLayer, content.transform);
    }

    private void CreateCircle(int currentLayer, Transform parent)
    {
        //int q = -currentLayer;
        for (int currentLine = -currentLayer; currentLine <= currentLayer; currentLine++)
        {
            int leftBorder = Mathf.Max(-currentLayer, -currentLine - currentLayer);
            int rightBorder = Mathf.Min(currentLayer, -currentLine + currentLayer);

            if (currentLine == -currentLayer || currentLine == currentLayer)
            {
                for (int tileInLine = leftBorder; tileInLine <= rightBorder; tileInLine++)
                    CreateTile(currentLine, tileInLine, parent);
            }
            else
            {
                CreateTile(currentLine, leftBorder, parent);
                CreateTile(currentLine, rightBorder, parent);
            }
        }
    }

    //for (int r = r1; r <= r2; r++)
    //{
    //    float xPos = tileSize * Mathf.Sqrt(3f) * (q + 0.5f * r);
    //    float zPos = tileSize * 1.5f * r;

    //    Vector3 position = new Vector3(xPos, 0f, zPos);
    //    CreateHexagon(position, parent, $"Tile {q}|{r} / {r1}|{r2}");
    //}

    private void CreateTile(int xIndex, int yIndex, Transform parent)
    {
        float xPos = tileSize * Mathf.Sqrt(3f) * (xIndex + 0.5f * yIndex);
        xPos /= 2f;

        //float xPos = tileSize * xIndex + (xIndex %2 == 0 ? -0.5f : 0f);

        float zPos = tileSize * yIndex * 0.85f; /*1.5f * yIndex / 2f;*/

        Vector3 position = new Vector3(xPos, 0f, zPos);
        CreateHexagon(position, parent, $"Tile {xIndex}|{yIndex}");
    }

    private void CreateHexagon(Vector3 position, Transform parent, string name, bool isNew = true)
    {
        GameObject hex;
        if (isNew)
            hex = Instantiate(hexPrefab, position, Quaternion.identity);
        else
            hex = Instantiate(oldHexPrefab, position, Quaternion.identity);

        hex.transform.SetParent(parent);
        hex.name = name;
    }
}
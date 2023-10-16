using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

namespace TileGenerator
{
    public static class SupportGenerator
    {
        //public static void GenerateHexagonOld(Transform parent)
        //{
        //    GameObject content = new GameObject("Container");

        //    int totalTiles = (3 * radius * (radius + 1)) + 1;
        //    int currentTile = 0;

        //    for (int q = -radius; q <= radius; q++)
        //    {
        //        int r1 = Mathf.Max(-radius, -q - radius);
        //        int r2 = Mathf.Min(radius, -q + radius);

        //        for (int r = r1; r <= r2; r++)
        //        {
        //            float xPos = tileSize * Mathf.Sqrt(3f) * (q + 0.5f * r);
        //            float zPos = tileSize * 1.5f * r;

        //            Vector3 position = new Vector3(xPos, 0f, zPos);
        //            CreateHexagon(position, content.transform, $"", false);
        //            currentTile++;
        //        }
        //    }

        //    content.transform.SetParent(parent);
        //}

        public static void GenerateHexagon(Transform parent, int currentLayer, int radius)
        {
            GameObject content = new GameObject("Container");

            //  q - line
            //  r1 - left border
            //  r2 - right border

            for (int rad = currentLayer; rad <= radius; rad++)
                CreateCircle(content.transform, rad);

            content.transform.SetParent(parent);
            //CreateCircle(currentLayer, content.transform);
        }

        private static void CreateCircle(Transform parent, int currentLayer)
        {
            for (int currentLine = -currentLayer; currentLine <= currentLayer; currentLine++)
            {
                int leftBorder = Mathf.Max(-currentLayer, -currentLine - currentLayer);
                int rightBorder = Mathf.Min(currentLayer, -currentLine + currentLayer);

                if (currentLine == -currentLayer || currentLine == currentLayer)
                {
                    for (int tileInLine = leftBorder; tileInLine <= rightBorder; tileInLine++)
                        CreateItem(parent, currentLine, tileInLine);
                }
                else
                {
                    CreateItem(parent, currentLine, leftBorder);
                    CreateItem(parent, currentLine, rightBorder);
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

        private static void CreateItem(Transform parent, int xIndex, int yIndex, float tileSize = 1f)
        {
            float xPos = tileSize * Mathf.Sqrt(3f) * (xIndex + 0.5f * yIndex);
            xPos /= 2f;

            //float xPos = tileSize * xIndex + (xIndex %2 == 0 ? -0.5f : 0f);
            float zPos = tileSize * yIndex * 0.85f; /*1.5f * yIndex / 2f;*/

            Vector3 position = new Vector3(xPos, 0f, zPos);

            if (TryGetHex(out Hex outHex))
                CreateHexagon(outHex, parent, position, $"Tile {xIndex}|{yIndex}");
        }

        private static bool TryGetHex(out Hex hex)
        {
            hex = HexPool.Instance.TryGetItem(BiomeType.Forsest, StructureType.None);

            Debug.Log($"Try Get: {hex}");
            return hex != null;
        }

        private static Hex CreateHexagon(Hex hex, Transform parent, Vector3 position, string name)
        {
            return TileCreator.Instance.CreateObject(hex, parent, position, name);
        }
    }
}
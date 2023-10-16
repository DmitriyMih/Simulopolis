using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

namespace TileGenerator
{
    public class ZoneGenerator : MonoBehaviour
    {
        [Header("Zone Settings")]
        [SerializeField] private BiomeType biomeType;

        [Space(5)]
        [Header("Generate Settings")]
        [SerializeField, Range(0, maxRadius)] private int currentLayer;
        [SerializeField, Range(0, maxRadius)] private int radius = 3;

        private const int maxRadius = 10;

        [Space(5)]
        [Header("Zone Data")]
        [SerializeField] private List<Hex> allTiles = new();

        [Space(5)]
        [SerializeField] private List<Hex> activeTiles = new();
        [SerializeField] private List<Hex> deactiveTiles = new();

#if UNITY_EDITOR
        private void OnValidate()
        {
            currentLayer = Mathf.Clamp(currentLayer, 0, Mathf.Min(maxRadius, radius));
            radius = Mathf.Clamp(radius, currentLayer, 20);
        }
#endif

        [ContextMenu("Generate")]
        private void Generate()
        {
            SupportGenerator.GenerateHexagon(transform, currentLayer, radius);
        }
    }
}
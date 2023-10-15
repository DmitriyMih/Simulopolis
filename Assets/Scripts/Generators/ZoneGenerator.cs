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
        private const int zoneRadius = 4;
        [SerializeField, Range(0, 5)] private int additionalRadius = 0;

        [Space(5)]
        [Header("Zone Data")]
        [SerializeField] private List<Hex> allTiles = new();

        [Space(5)]
        [SerializeField] private List<Hex> activeTiles = new();
        [SerializeField] private List<Hex> deactiveTiles = new();

        [ContextMenu("Generate")]
        private void Generate()
        {

        }
    }
}
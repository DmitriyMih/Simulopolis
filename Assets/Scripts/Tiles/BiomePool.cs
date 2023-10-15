using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TileSystem
{
    [CreateAssetMenu(menuName = "Create Biome", fileName = "New Biome")]
    public class BiomePool : ScriptableObject
    {
        public BiomeType BiomeType;
        public List<Hex> BiomTilesPool = new();

        private void OnValidate()
        {
            for (int i = 0; i < BiomTilesPool.Count; i++)
            {
                if (BiomTilesPool[i] != null)
                    BiomTilesPool[i].ChangeType(BiomeType);
            }

            AssetDatabase.Refresh();
        }
    }
}
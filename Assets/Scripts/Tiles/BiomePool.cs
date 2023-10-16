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
        public List<Hex> BiomeTilesPool = new();

        private void OnValidate()
        {
            for (int i = 0; i < BiomeTilesPool.Count; i++)
            {
                if (BiomeTilesPool[i] != null)
                    BiomeTilesPool[i].ChangeType(BiomeType);
            }

            AssetDatabase.Refresh();
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TileSystem
{
    public class Hex : MonoBehaviour
    {
        [SerializeField] private HexData hexData;
        public HexData HexData => hexData;

        public void ChangeType(BiomeType biomeType)
        {
            hexData.BiomeType = biomeType;
            string outName = $"Hex - {hexData.StructureType} - {hexData.BiomeType}"; 
            
            string assetPath = AssetDatabase.GetAssetPath(GetInstanceID());
            AssetDatabase.RenameAsset(assetPath, outName);

            AssetDatabase.SaveAssets();
        }
    }

    [Serializable]
    public class HexData
    {
        public BiomeType BiomeType;
        public StructureType StructureType;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem
{
    [RequireComponent(typeof(TileCreator))]
    public sealed class HexPool : MonoBehaviour
    {
        public static HexPool Instance;

        [SerializeField] private List<BiomePool> biomePools = new();

        private void Awake()
        {
            Instance = this;
        }

        public Hex TryGetItem(BiomeType biomeType, StructureType structureType)
        {
            if (TryGetBiomePool(out BiomePool outBiome, biomeType) && TryGetHex(out Hex outHex, outBiome, structureType))
                return outHex;
            else
                return null;
        }

        private bool TryGetHex(out Hex hex, BiomePool biomePool, StructureType structureType)
        {
            hex = null;
            hex = biomePool.BiomeTilesPool.Find(x => x.HexData.StructureType == structureType);

            Debug.Log($"Try Get Hex: {hex}");
            return hex != null;
        }

        private bool TryGetBiomePool(out BiomePool biomePool, BiomeType biomeType)
        {
            biomePool = biomePools.Find(x => x.BiomeType == biomeType);
            
            Debug.Log($"Try Get Hex: {biomePool}");
            return biomePool != null;
        }
    }
}
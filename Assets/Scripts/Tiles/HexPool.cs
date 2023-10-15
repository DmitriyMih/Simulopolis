using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem
{
    public sealed class HexPool : MonoBehaviour
    {
        [SerializeField] private List<BiomePool> biomPools = new();
    }
}
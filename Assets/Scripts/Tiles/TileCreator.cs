using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem
{
    [RequireComponent(typeof(HexPool))]
    public class TileCreator : MonoBehaviour
    {
        public static TileCreator Instance;

        private void Awake()
        {
            Instance = this;
        }

        public Hex CreateObject(Hex prefab, Transform parent, Vector3 position, string name)
        {
            Hex hex = Instantiate(prefab, position, Quaternion.identity);
            hex.transform.SetParent(parent);
            hex.name = name;
            return hex;
        }
    }
}
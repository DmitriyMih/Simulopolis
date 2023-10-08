using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLevelController : MonoBehaviour
{
    [SerializeField] private int level;

    public Action<int> OnLevelChanged;

    private void Awake()
    {
        ChangeLevel();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        ChangeLevel();
    }
#endif

    private void ChangeLevel()
    {
        OnLevelChanged?.Invoke(level);
    }
}
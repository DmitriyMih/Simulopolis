using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLevelController : MonoBehaviour
{
    [SerializeField] private int level;

    public Action<int> OnLevelChanged;

    private void OnValidate()
    {
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        OnLevelChanged?.Invoke(level);
    }
}
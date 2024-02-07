﻿using UnityEngine;

namespace GamePlay.Enemy.Spawn.Processor.Definition.ToggleButtons.Runtime
{
    public class ToggleTest : MonoBehaviour
    {
        [EnemyToggle] [SerializeField] private bool _a;

        [SerializeField] [HideInInspector] private EnemyTypesDictionary _switches = new();
    }
}
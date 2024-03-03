using System;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Logs
{
    [Serializable]
    public class LocalTransformDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
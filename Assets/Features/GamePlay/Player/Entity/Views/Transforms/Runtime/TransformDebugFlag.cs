using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Runtime
{
    [Serializable]
    public class TransformDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
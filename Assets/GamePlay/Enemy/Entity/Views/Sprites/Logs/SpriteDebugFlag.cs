using System;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Sprites.Logs
{
    [Serializable]
    public class SpriteDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
using System;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Sprites.Logs
{
    [Serializable]
    public class SpriteDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
using System;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Animators.Logs
{
    [Serializable]
    public class AnimatorDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Logs
{
    [Serializable]
    public class RotationSyncDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
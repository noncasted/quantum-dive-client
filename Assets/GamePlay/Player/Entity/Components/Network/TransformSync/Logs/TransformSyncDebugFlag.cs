using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Network.TransformSync.Logs
{
    [Serializable]
    public class TransformSyncDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
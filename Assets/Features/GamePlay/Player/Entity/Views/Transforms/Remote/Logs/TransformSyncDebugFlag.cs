using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Remote.Logs
{
    [Serializable]
    public class TransformSyncDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
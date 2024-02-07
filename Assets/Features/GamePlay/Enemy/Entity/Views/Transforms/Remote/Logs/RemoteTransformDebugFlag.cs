using System;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Transforms.Remote.Logs
{
    [Serializable]
    public class RemoteTransformDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
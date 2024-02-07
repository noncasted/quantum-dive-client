using System;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.RigidBodies.Logs
{
    [Serializable]
    public class RigidBodyDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
using System;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Logs
{
    [Serializable]
    public class RemoteStateMachineDebugFlag
    {
        [SerializeField] private bool _isActive;

        public bool IsActive => _isActive;
    }
}
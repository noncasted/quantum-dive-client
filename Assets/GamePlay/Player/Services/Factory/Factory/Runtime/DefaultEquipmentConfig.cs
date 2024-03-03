using System;
using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Factory.Factory.Runtime
{
    [Serializable]
    public class DefaultEquipmentConfig
    {
        [SerializeField] [Indent] private EquipmentConfig[] _equipment;

        public IReadOnlyList<IEquipmentConfig> Equipment => _equipment;
    }
}
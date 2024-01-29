using System;
using System.Collections.Generic;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Services.Factory.Factory.Runtime
{
    [Serializable]
    public class DefaultEquipmentConfig
    {
        [SerializeField] [Indent] private EquipmentFactory[] _equipment;

        public IReadOnlyList<IEquipmentFactory> Equipment => _equipment;
    }
}
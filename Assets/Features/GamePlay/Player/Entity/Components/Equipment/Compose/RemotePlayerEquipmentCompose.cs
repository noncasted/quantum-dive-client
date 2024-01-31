﻿using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Common;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Local;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Components.Equipment.Locker.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Player.Entity.Components.Equipment.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemotePlayer_ComponentsCompose", 
        menuName = PlayerEquipmentRoutes.Root + "Compose/Remote")]
    public class RemotePlayerEquipmentCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private RemoteEquipperFactory _equipper;
        [SerializeField] private EquipmentLockerFactory _locker;
        [SerializeField] private EquipmentSlotsStorageFactory _slotsStorage;
        
        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _equipper,
            _locker,
            _slotsStorage
        };
    }
}
using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.Equipment.Common;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Factory;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Components.Equipment.Locker.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemotePlayer_ComponentsCompose", 
        menuName = PlayerEquipmentRoutes.Root + "Compose/Remote")]
    public class RemotePlayerEquipmentCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EquipmentFactoryComponentFactory _factory;
        [SerializeField] private RemoteEquipperFactory _equipper;
        [SerializeField] private EquipmentLockerFactory _locker;
        [SerializeField] private EquipmentSlotsStorageFactory _slotsStorage;
        
        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _factory,
            _equipper,
            _locker,
            _slotsStorage
        };
    }
}
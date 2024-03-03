using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Common;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Factory;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Local;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Remote;
using GamePlay.Player.Entity.Components.Equipment.Locker.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Equipment.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalPlayer_ComponentsCompose",
        menuName = PlayerEquipmentRoutes.Root + "Compose/Local")]
    public class LocalPlayerEquipmentCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EquipmentFactoryComponentFactory _factory;
        [SerializeField] private LocalEquipperFactory _localEquipper;
        [SerializeField] private RemoteEquipperFactory _remoteEquipper;
        [SerializeField] private EquipmentLockerFactory _locker;
        [SerializeField] private EquipmentSlotsStorageFactory _slotsStorage;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _factory,
            _localEquipper,
            _remoteEquipper,
            _locker,
            _slotsStorage
        };
    }
}
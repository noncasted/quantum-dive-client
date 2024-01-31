using Features.GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Local;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Remote;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Factory.Common;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Root.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowFactoryRoutes.ComponentName,
        menuName = BowFactoryRoutes.ComponentPath)]
    public class BowConfig : EquipmentConfig
    {
        [SerializeField] [Indent] private BowSlotDefinition _definition;
        [SerializeField] [Indent] private LocalBowConfig _local;
        [SerializeField] [Indent] private RemoteBowConfig _remote;

        public override IEquipmentInstanceConfig Local => _local;
        public override IEquipmentInstanceConfig Remote => _remote;
        public override SlotDefinition Slot => _definition;
    }
}
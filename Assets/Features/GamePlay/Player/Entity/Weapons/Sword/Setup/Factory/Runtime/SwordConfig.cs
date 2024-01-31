using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Storage.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Local;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Remote;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Factory.Common;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordFactoryRoutes.ComponentName,
        menuName = SwordFactoryRoutes.ComponentPath)]
    public class SwordConfig : EquipmentConfig
    {
        [SerializeField] [Indent] private SwordSlotDefinition _definition;
        [SerializeField] [Indent] private LocalSwordConfig _local;
        [SerializeField] [Indent] private RemoteSwordConfig _remote;

        public override IEquipmentInstanceConfig Local => _local;
        public override IEquipmentInstanceConfig Remote => _remote;
        public override SlotDefinition Slot => _definition;
    }
}
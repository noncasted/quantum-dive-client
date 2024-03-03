using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Definition.Common;
using GamePlay.Player.Entity.Weapons.Bow.Definition.Local;
using GamePlay.Player.Entity.Weapons.Bow.Definition.Remote;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Definition.Compose
{
    [CreateAssetMenu(fileName = BowConfigRoutes.ComposeName, menuName = BowConfigRoutes.ComposePath)]
    public class BowEquipmentConfig : EquipmentConfig
    {
        [SerializeField] private LocalBowConfig _local;
        [SerializeField] private RemoteBowConfig _remote;
        [SerializeField] private SlotDefinition _slot;
        
        public override IEquipmentInstanceConfig Local => _local;
        public override IEquipmentInstanceConfig Remote => _remote;
        public override SlotDefinition Slot => _slot;
    }
}
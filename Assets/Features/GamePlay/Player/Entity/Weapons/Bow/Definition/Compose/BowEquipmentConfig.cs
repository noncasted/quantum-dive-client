using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Definition.Local;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Definition.Common
{
    //[CreateAssetMenu(fileName = BowConfigRoutes.)]
    public class BowEquipmentConfig : EquipmentConfig
    {
        [SerializeField] private LocalBowConfig _local;
        
        public override IEquipmentInstanceConfig Local { get; }
        public override IEquipmentInstanceConfig Remote { get; }
        public override SlotDefinition Slot { get; }
    }
}
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Components.Equipment.Slots.Definitions.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Definition.Common;
using GamePlay.Player.Entity.Weapons.Sword.Definition.Local;
using GamePlay.Player.Entity.Weapons.Sword.Definition.Remote;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Definition.Compose
{
    [CreateAssetMenu(fileName = SwordConfigRoutes.ComposeName, menuName = SwordConfigRoutes.ComposePath)]
    public class SwordEquipmentConfig : EquipmentConfig
    {
        [SerializeField] private LocalSwordConfig _local;
        [SerializeField] private RemoteSwordConfig _remote;
        [SerializeField] private SlotDefinition _slot;
        
        public override IEquipmentInstanceConfig Local => _local;
        public override IEquipmentInstanceConfig Remote => _remote;
        public override SlotDefinition Slot => _slot;
    }

}
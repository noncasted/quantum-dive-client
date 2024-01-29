using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Bootstrap;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Factory.Common;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordFactoryRoutes.ComponentName,
        menuName = SwordFactoryRoutes.ComponentPath)]
    public class SwordFactoryAsset : EquipmentFactory
    {
        [SerializeField] [Indent] private SwordBuilder _localPrefab;
        [SerializeField] [Indent] private SwordBuilder _remotePrefab;
        [SerializeField] [Indent] private SwordSlotDefinition _definition;

        public override async UniTaskVoid CreateLocal(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent)
        {
            var sword = Instantiate(_localPrefab);

            var equipment = await sword.Build(parent, _definition);

            binder.Bind(_definition, sword.transform);
            storage.Equip(equipment);
        }

        public override async UniTaskVoid CreateRemote(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent)
        {
            var sword = Instantiate(_remotePrefab);

            var equipment = await sword.Build(parent, _definition);

            binder.Bind(_definition, sword.transform);
            storage.Equip(equipment);
        }
    }
}
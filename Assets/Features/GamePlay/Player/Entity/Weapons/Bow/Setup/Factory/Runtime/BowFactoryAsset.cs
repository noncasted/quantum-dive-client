using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Abstract.Factory;
using GamePlay.Player.Entity.Equipment.Slots.Binder.Runtime;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Factory.Common;
using GamePlay.Player.Entity.Weapons.Bow.Setup.Root.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowFactoryRoutes.ComponentName,
        menuName = BowFactoryRoutes.ComponentPath)]
    public class BowFactoryAsset : EquipmentFactory
    {
        [SerializeField] [Indent] private BowSlotDefinition _definition;

        public override async UniTaskVoid CreateLocal(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent)
        {
            // var bow = Instantiate(_localPrefab);
            //
            // var equipment = await bow.Build(parent, _definition);
            //
            // binder.Bind(_definition, bow.transform);
            // storage.Equip(equipment);
        }

        public override async UniTaskVoid CreateRemote(
            IEquipmentSlotsStorage storage,
            IEquipmentSlotBinder binder,
            LifetimeScope parent)
        {
            // var bow = Instantiate(_remotePrefab);
            //
            // var equipment = await bow.Build(parent, _definition);
            //
            // binder.Bind(_definition, bow.transform);
            // storage.Equip(equipment);
        }
    }
}
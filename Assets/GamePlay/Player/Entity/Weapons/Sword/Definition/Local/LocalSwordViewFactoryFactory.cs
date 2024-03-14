using GamePlay.Player.Entity.Components.Equipment.Definition;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Definition.Local
{
    [DisallowMultipleComponent]
    public class LocalSwordViewFactoryFactory : EquipmentViewFactory
    {
        [SerializeField] private AttackAreaFactory _attackArea;
        [SerializeField] private SwordTransformFactory _transform;
        
        public override void CreateViews(IServiceCollection services, IScopedEntityUtils utils)
        {
            _attackArea.Create(services, utils);
            _transform.Create(services, utils);
        }
    }
}
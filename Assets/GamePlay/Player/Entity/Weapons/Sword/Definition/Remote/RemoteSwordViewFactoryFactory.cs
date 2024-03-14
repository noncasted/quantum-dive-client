using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Definition.Remote
{
    [DisallowMultipleComponent]
    public class RemoteSwordViewFactoryFactory : EquipmentViewFactory
    {
        [SerializeField] private SwordTransformFactory _transform;

        public override void CreateViews(IServiceCollection services, IScopedEntityUtils utils)
        {
            _transform.Create(services, utils);
        }
    }
}
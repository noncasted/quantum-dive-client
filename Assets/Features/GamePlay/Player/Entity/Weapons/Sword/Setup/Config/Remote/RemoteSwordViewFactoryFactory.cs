using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Views.Transforms;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Remote
{
    [DisallowMultipleComponent]
    public class RemoteSwordViewFactoryFactory : ScopedEntityViewFactory, IEntityViewFactory
    {
        [SerializeField] private SwordTransformFactory _transform;

        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _transform.Create(services, utils);
        }
    }
}
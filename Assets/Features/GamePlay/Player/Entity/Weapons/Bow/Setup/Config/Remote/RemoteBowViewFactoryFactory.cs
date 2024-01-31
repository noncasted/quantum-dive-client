using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Remote
{
    [DisallowMultipleComponent]
    public class RemoteBowViewFactoryFactory : ScopedEntityViewFactory, IEntityViewFactory
    {
        [SerializeField] private BowSpriteFactory _sprite;
        [SerializeField] private BowTransformFactory _transform;
        [SerializeField] private BowShootPointFactory _shootPoint;
        [SerializeField] private BowGameObjectFactory _gameObject;
        [SerializeField] private BowAnimatorFactory _animator;
        [SerializeField] private BowPivotsFactory _pivots;
        [SerializeField] private BowArrowFactory _arrow;

        public override void CreateViews(IServiceCollection services, IEntityUtils utils)
        {
            _sprite.Create(services, utils);
            _transform.Create(services, utils);
            _shootPoint.Create(services, utils);
            _gameObject.Create(services, utils);
            _animator.Create(services, utils);
            _pivots.Create(services, utils);
            _arrow.Create(services, utils);
        }
    }
}
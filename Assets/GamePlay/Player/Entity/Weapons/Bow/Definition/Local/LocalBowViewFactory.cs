using GamePlay.Player.Entity.Components.Equipment.Definition;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Definition.Local
{
    [DisallowMultipleComponent]
    public class LocalBowViewFactory : EquipmentViewFactory
    {
        [SerializeField] private BowTransformFactory _transform;
        [SerializeField] private BowShootPointFactory _shootPoint;
        [SerializeField] private BowGameObjectFactory _gameObject;
        [SerializeField] private BowAnimatorFactory _animator;
        [SerializeField] private BowArrowFactory _arrow;

        public override void CreateViews(IServiceCollection services, IScopedEntityUtils utils)
        {
            _transform.Create(services, utils);
            _shootPoint.Create(services, utils);
            _gameObject.Create(services, utils);
            _animator.Create(services, utils);
            _arrow.Create(services, utils);
        }
    }
}
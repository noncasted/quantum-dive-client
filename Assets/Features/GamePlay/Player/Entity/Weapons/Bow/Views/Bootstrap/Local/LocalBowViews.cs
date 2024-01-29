using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.Animators.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Arrow.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Sprites.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Bootstrap.Local
{
    [DisallowMultipleComponent]
    public class LocalBowViews : MonoBehaviour, IPlayerContainerBuilder
    { 
        [SerializeField] private BowSpriteFactory _sprite;
        [SerializeField] private BowTransformFactory _transform;
        [SerializeField] private BowShootPointFactory _shootPoint;
        [SerializeField] private BowGameObjectFactory _gameObject;
        [SerializeField] private BowAnimatorFactory _animator;
        [SerializeField] private BowPivotsFactory _pivots;
        [SerializeField] private BowArrowFactory _arrow;
        
        public void OnBuild(IServiceCollection services, ICallbackRegister callbackRegister)
        {
            _sprite.Create(services, callbackRegister);
            _transform.Create(services, callbackRegister);
            _shootPoint.Create(services, callbackRegister);
            _gameObject.Create(services, callbackRegister);
            _animator.Create(services, callbackRegister);
            _pivots.Create(services, callbackRegister);
            _arrow.Create(services, callbackRegister);
        }
    }
}
using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Range.States.Shoot.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.States.Shoot.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyShootRoutes.RemoteName,
        menuName = EnemyShootRoutes.RemotePath)]
    public class RemoteShootFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private ShootAnimationFactory _animation;
        [SerializeField] private ShootDefinition _definition;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var animation = _animation.Create();
            
            services.Register<RemoteShoot>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}
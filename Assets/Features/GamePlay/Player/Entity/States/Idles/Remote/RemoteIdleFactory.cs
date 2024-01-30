using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Idles.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Idles.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdleRoutes.RemoteName,
        menuName = IdleRoutes.RemotePath)]
    public class RemoteIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private IdleAnimationFactory _animation;
        [SerializeField] [Indent] private IdleDefinition _definition;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.Create();
            
            services.Register<PlayerRemoteIdle>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Common.Tools.UniversalAnimators.Abstract;
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
        [SerializeField] [Indent] private BaseAnimationData _animation;
        [SerializeField] [Indent] private IdleDefinition _definition;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.CreateAnimation();
            
            services.Register<PlayerRemoteIdle>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Roll.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRollRoutes.RemoteName,
        menuName = PlayerRollRoutes.RemotePath)]
    public class RemoteRollFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private BaseAnimationData _animation;
        [SerializeField] private RollDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.CreateAnimation();

            services.Register<RemoteRoll>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}
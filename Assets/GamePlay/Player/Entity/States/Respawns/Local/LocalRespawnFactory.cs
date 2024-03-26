using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Respawns.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Respawns.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RespawnRoutes.LocalName,
        menuName = RespawnRoutes.LocalPath)]
    public class LocalRespawnFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _animation;
        [SerializeField] [Indent] private RespawnDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.CreateAnimation();

            services.Register<LocalRespawn>()
                .As<IRespawn>()
                .WithParameter(_definition)
                .WithParameter(animation);
        }
    }
}
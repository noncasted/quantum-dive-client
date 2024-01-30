using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Roll.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Roll.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerRollRoutes.RemoteName,
        menuName = PlayerRollRoutes.RemotePath)]
    public class RemoteRollFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RollAnimationFactory _animation;
        [SerializeField] private RollDefinition _definition;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.Create();

            services.Register<RemoteRoll>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}
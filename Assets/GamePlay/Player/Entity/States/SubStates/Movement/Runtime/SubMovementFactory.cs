using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.SubStates.Movement.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SubMovementRoutes.StateName, menuName = SubMovementRoutes.StatePath)]
    public class SubMovementFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _runAnimation;
        [SerializeField] [Indent] private BaseAnimationData _walkAnimation;
        [SerializeField] [Indent] private BaseAnimationData _idleAnimation;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var runAnimation = _runAnimation.CreateAnimation();
            var walkAnimation = _walkAnimation.CreateAnimation();
            var idleAnimation = _idleAnimation.CreateAnimation();
                        
            services.Register<SubMovement>()
                .As<ISubMovement>()
                .WithParameter(runAnimation, "runAnimation")
                .WithParameter(walkAnimation, "walkAnimation")
                .WithParameter(idleAnimation, "idleAnimation");
        }
    }
}
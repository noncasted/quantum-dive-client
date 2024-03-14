using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.SubStates.Pushes.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.LocalName, menuName = BowStrafeRoutes.LocalPath)]
    public class StrafeFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private PushParams _pushParams;
        [SerializeField] [Indent] private BaseAnimationData _playerAnimation;
        [SerializeField] [Indent] private BaseAnimationData _bowAnimation;
        [SerializeField] [Indent] private StrafeDefinition _definition;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var playerAnimation = _playerAnimation.CreateAnimation();
            var bowAnimation = _bowAnimation.CreateAnimation();

            services.Register<StrafeEntry>()
                .WithParameter(_transitions)
                .AsCallbackListener();

            services.Register<Strafe>()
                .WithParameter(_definition)
                .WithParameter(_pushParams)
                .WithParameter(_transitions)
                .WithParameter(playerAnimation, "playerAnimation")
                .WithParameter(bowAnimation, "bowAnimation")
                .AsCallbackListener()
                .As<IStrafe>();
        }
    }
}
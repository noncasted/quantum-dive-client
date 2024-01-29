using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common.Animations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.LocalName, menuName = BowStrafeRoutes.LocalPath)]
    public class StrafeFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private PushParams _pushParams;
        [SerializeField] [Indent] private PlayerStrafeAnimationFactory _playerAnimation;
        [SerializeField] [Indent] private BowStrafeAnimationFactory _bowAnimation;
        [SerializeField] [Indent] private StrafeDefinition _definition;
        [SerializeField] [Indent] private PlayerStateDefinition[] _transitions;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var playerAnimation = _playerAnimation.Create();
            var bowAnimation = _bowAnimation.Create();

            services.Register<StrafeEntry>()
                .WithParameter(_transitions)
                .AsCallbackListener();

            services.Register<Strafe>()
                .WithParameter(_definition)
                .WithParameter(_pushParams)
                .WithParameter(_transitions)
                .WithParameter(playerAnimation)
                .WithParameter(bowAnimation)
                .AsCallbackListener()
                .As<IStrafe>();
        }
    }
}
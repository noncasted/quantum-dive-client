using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Melee.States.Attack.Common;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Animation;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemies.Types.Melee.States.Attack.Debug;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.LocalName,
        menuName = EnemyMeleeAttackRoutes.LocalPath)]
    public class LocalMeleeAttackFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private MeleeAttackAnimationFactory _animation;
        [SerializeField] private MeleeAttackDefinition _definition;
        [SerializeField] private MeleeAttackConfig _config;
        [SerializeField] private MeleeAttackGizmosConfig _gizmosConfig;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.RegisterInstance(_config)
                .As<IMeleeAttackConfig>();

            services.Register<TargetChecker>()
                .As<ITargetChecker>();

            var animation = _animation.Create();

            services.Register<LocalMeleeAttack>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .As<IMeleeAttack>();

            services.Register<Transition>()
                .WithParameter(_definition)
                .As<IMeleeAttackTransition>();

            services.Register<GizmosDrawer>()
                .WithParameter<IMeleeAttackGizmosConfig>(_gizmosConfig)
                .As<IMeleeAttackGizmosDrawer>();
        }
    }
}
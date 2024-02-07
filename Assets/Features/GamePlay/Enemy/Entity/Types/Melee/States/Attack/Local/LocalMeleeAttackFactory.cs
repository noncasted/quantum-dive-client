using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Animation;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Debug;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.LocalName,
        menuName = EnemyMeleeAttackRoutes.LocalPath)]
    public class LocalMeleeAttackFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private MeleeAttackAnimationFactory _animation;
        [SerializeField] private MeleeAttackDefinition _definition;
        [SerializeField] private MeleeAttackConfig _config;
        [SerializeField] private MeleeAttackGizmosConfig _gizmosConfig;

        public void Create(IServiceCollection services, IEntityUtils utils)
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
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Debug;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.LocalName,
        menuName = EnemyMeleeAttackRoutes.LocalPath)]
    public class LocalMeleeAttackFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private MeleeAttackDefinition _definition;
        [SerializeField] private MeleeAttackConfig _config;
        [SerializeField] private MeleeAttackGizmosConfig _gizmosConfig;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterInstance(_config)
                .As<IMeleeAttackConfig>();

            services.Register<TargetChecker>()
                .As<ITargetChecker>();

            services.Register<LocalMeleeAttack>()
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
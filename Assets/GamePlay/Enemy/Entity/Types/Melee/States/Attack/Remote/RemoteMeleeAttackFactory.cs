using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.RemoteName,
        menuName = EnemyMeleeAttackRoutes.RemotePath)]
    public class RemoteMeleeAttackFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private MeleeAttackDefinition _definition;
        [SerializeField] private MeleeAttackConfig _config;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterInstance(_config)
                .As<IMeleeAttackConfig>();

            services.Register<RemoteMeleeAttack>()
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}
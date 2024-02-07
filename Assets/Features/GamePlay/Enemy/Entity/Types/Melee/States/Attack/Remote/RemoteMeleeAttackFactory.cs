using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Animation;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.RemoteName,
        menuName = EnemyMeleeAttackRoutes.RemotePath)]
    public class RemoteMeleeAttackFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private MeleeAttackAnimationFactory _animation;
        [SerializeField] private MeleeAttackDefinition _definition;
        [SerializeField] private MeleeAttackConfig _config;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.Create();

            services.RegisterInstance(_config)
                .As<IMeleeAttackConfig>();

            services.Register<RemoteMeleeAttack>()
                .WithParameter(animation)
                .WithParameter(_definition)
                .AsCallbackListener();
        }
    }
}
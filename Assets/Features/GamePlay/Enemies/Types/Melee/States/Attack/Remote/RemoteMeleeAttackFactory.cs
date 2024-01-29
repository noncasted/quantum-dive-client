using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Melee.States.Attack.Common;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Animation;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeAttackRoutes.RemoteName,
        menuName = EnemyMeleeAttackRoutes.RemotePath)]
    public class RemoteMeleeAttackFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private MeleeAttackAnimationFactory _animation;
        [SerializeField] private MeleeAttackDefinition _definition;
        [SerializeField] private MeleeAttackConfig _config;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
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
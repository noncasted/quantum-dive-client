using Common.Architecture.Entities.Common.DefaultCallbacks;
using GamePlay.Common.Damages;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Config;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages
{
    public class DamageDealer : IEntitySwitchListener
    {
        public DamageDealer(
            IDamageTrigger trigger,
            IMeleeAttackConfig config,
            IEnemyPosition position)
        {
            _trigger = trigger;
            _config = config;
            _position = position;
        }

        private readonly IDamageTrigger _trigger;
        private readonly IMeleeAttackConfig _config;
        private readonly IEnemyPosition _position;

        public void OnEnabled()
        {
            _trigger.Triggered += OnTriggered;
        }

        public void OnDisabled()
        {
            _trigger.Triggered -= OnTriggered;
        }

        private void OnTriggered(IDamageReceiver receiver)
        {
            var direction = receiver.Position - _position.Position;
            var damage = new Damage(1, _config.PushForce, direction);

            receiver.ReceiveDamage(damage);
        }
    }
}
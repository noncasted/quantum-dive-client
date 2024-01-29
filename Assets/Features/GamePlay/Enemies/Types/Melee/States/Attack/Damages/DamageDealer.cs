using GamePlay.Common.Damages;
using GamePlay.Enemies.Entity.Setup.EventLoop;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Enemies.Types.Melee.States.Attack.Common.Config;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Damages
{
    public class DamageDealer : IEnemySwitchListener
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
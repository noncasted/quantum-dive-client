using System;
using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    public class DamageReceiver : IPlayerSwitchListener, IDamageReceiverHandler
    {
        public DamageReceiver(IDamageReceiverTrigger trigger)
        {
            _trigger = trigger;
        }

        private readonly IDamageReceiverTrigger _trigger;

        public event Action<Damage> Damaged;

        public void OnEnabled()
        {
            _trigger.Triggered += OnTriggered;
        }

        public void OnDisabled()
        {
            _trigger.Triggered -= OnTriggered;
        }

        private void OnTriggered(Damage damage)
        {
            Damaged?.Invoke(damage);
        }

        public void Enable()
        {
            _trigger.Enable();
        }

        public void Disable()
        {
            _trigger.Disable();
        }
    }
}
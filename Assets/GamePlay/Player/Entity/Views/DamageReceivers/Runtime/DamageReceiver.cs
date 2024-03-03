using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Common.Architecture.Lifetimes.Viewables;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    public class DamageReceiver : IEntitySwitchLifetimeListener, IDamageReceiverHandler
    {
        public DamageReceiver(IDamageReceiverTrigger trigger)
        {
            _trigger = trigger;
        }

        private readonly IDamageReceiverTrigger _trigger;

        private readonly IViewableDelegate<Damage> _damaged = new ViewableDelegate<Damage>();

        public IViewableDelegate<Damage> Damaged => _damaged; 

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _trigger.Triggered.Listen(lifetime, OnTriggered);
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
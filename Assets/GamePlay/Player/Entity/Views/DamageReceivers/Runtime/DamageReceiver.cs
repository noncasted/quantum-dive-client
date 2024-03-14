using Common.DataTypes.Reactive;
using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Views.DamageReceivers.Abstract;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;

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
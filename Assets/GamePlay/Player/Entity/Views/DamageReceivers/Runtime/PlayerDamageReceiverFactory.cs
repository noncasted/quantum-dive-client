using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerDamageReceiverFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private DamageReceiverTrigger _trigger;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<DamageReceiver>()
                .WithParameter<IDamageReceiverTrigger>(_trigger)
                .As<IDamageReceiverHandler>()
                .AsCallbackListener();
        }
    }
}
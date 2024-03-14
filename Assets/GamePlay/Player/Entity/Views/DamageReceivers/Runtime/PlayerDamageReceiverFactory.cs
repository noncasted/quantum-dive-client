using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    [DisallowMultipleComponent]
    public class PlayerDamageReceiverFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private DamageReceiverTrigger _trigger;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<DamageReceiver>()
                .WithParameter<IDamageReceiverTrigger>(_trigger)
                .As<IDamageReceiverHandler>()
                .AsCallbackListener();
        }
    }
}
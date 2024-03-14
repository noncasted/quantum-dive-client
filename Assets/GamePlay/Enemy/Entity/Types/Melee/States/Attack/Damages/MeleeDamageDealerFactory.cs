using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages
{
    public class MeleeDamageDealerFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private DamageTrigger _trigger;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.RegisterComponent(_trigger)
                .As<IDamageTrigger>();

            services.Register<DamageDealer>()
                .AsCallbackListener();
        }
    }
}
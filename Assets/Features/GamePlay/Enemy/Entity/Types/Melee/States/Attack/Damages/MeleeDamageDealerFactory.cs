using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages
{
    public class MeleeDamageDealerFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private DamageTrigger _trigger;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterComponent(_trigger)
                .As<IDamageTrigger>();

            services.Register<DamageDealer>()
                .AsCallbackListener();
        }
    }
}
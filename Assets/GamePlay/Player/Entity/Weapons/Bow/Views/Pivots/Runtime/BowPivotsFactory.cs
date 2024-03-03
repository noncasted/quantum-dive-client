using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    [DisallowMultipleComponent]
    public class BowPivotsFactory : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private BowPivotsProvider _provider;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowPivots>()
                .As<IBowPivotsProvider>()
                .WithParameter(_provider);
        }
    }
}
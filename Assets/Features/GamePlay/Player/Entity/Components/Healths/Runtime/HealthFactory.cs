using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Healths.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Healths.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HealthRoutes.ComponentName,
        menuName = HealthRoutes.ComponentPath)]
    public class HealthFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private int _startHealth = 3;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<Health>()
                .As<IHealth>()
                .WithParameter(_startHealth);
        }
    }
}
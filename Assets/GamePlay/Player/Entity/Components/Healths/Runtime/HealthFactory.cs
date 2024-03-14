using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
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

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<Health>()
                .As<IHealth>()
                .WithParameter(_startHealth);
        }
    }
}
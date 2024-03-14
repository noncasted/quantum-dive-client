using GamePlay.Enemy.Entity.Components.Sorting.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.Sorting.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySpriteSortingRoutes.ComponentName,
        menuName = EnemySpriteSortingRoutes.ComponentPath)]
    public class SpriteSortingFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private SpriteSortingConfig _config;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<SpriteSorting>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}
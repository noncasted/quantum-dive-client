using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.Sorting.Common;
using Common.Architecture.Entities.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.Sorting.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySpriteSortingRoutes.ComponentName,
        menuName = EnemySpriteSortingRoutes.ComponentPath)]
    public class SpriteSortingFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private SpriteSortingConfig _config;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SpriteSorting>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}
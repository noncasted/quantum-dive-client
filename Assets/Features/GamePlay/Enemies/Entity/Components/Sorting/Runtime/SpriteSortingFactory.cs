using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.Sorting.Common;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.Sorting.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemySpriteSortingRoutes.ComponentName,
        menuName = EnemySpriteSortingRoutes.ComponentPath)]
    public class SpriteSortingFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private SpriteSortingConfig _config;

        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<SpriteSorting>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}
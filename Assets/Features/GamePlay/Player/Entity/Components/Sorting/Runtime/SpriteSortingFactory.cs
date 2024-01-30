using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Sorting.Common;

using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Sorting.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SortingRoutes.ComponentName,
        menuName = SortingRoutes.ComponentPath)]
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
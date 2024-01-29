using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Components.Sorting.Common;
using GamePlay.Player.Entity.Setup.Abstract;
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
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<SpriteSorting>()
                .WithParameter(_config)
                .AsCallbackListener();
        }
    }
}
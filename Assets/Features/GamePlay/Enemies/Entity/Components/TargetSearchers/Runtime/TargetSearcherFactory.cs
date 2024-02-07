using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Common;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Debug.Gizmos;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TargetSearcherRoutes.ComponentName,
        menuName = TargetSearcherRoutes.ComponentPath)]
    public class TargetSearcherFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private TargetSearchConfig _config;
        [SerializeField] [Indent] private TargetSearchGizmosConfig _gizmosConfig;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SearchGizmos>()
                .WithParameter<ISearchGizmosConfig>(_gizmosConfig)
                .As<ISearchGizmos>();
            
            services.Register<TargetSearcher>()
                .WithParameter<ISearchConfig>(_config)
                .As<ITargetSearcher>()
                .As<ITargetProvider>()
                .AsCallbackListener();
        }
    }
}
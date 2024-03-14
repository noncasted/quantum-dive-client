using GamePlay.Enemy.Entity.Components.TargetSearchers.Common;
using GamePlay.Enemy.Entity.Components.TargetSearchers.Debug.Gizmos;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TargetSearcherRoutes.ComponentName,
        menuName = TargetSearcherRoutes.ComponentPath)]
    public class TargetSearcherFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private TargetSearchConfig _config;
        [SerializeField] [Indent] private TargetSearchGizmosConfig _gizmosConfig;
        
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
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
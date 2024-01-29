using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Common;
using GamePlay.Enemies.Entity.Components.TargetSearchers.Debug.Gizmos;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TargetSearcherRoutes.ComponentName,
        menuName = TargetSearcherRoutes.ComponentPath)]
    public class TargetSearcherFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] [Indent] private TargetSearchConfig _config;
        [SerializeField] [Indent] private TargetSearchGizmosConfig _gizmosConfig;
        
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
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
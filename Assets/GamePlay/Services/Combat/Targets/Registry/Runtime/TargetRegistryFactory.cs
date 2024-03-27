using Cysharp.Threading.Tasks;
using GamePlay.Services.Combat.Targets.Registry.Abstract;
using GamePlay.Services.Targets.Registry.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Targets.Registry.Runtime
{
    [CreateAssetMenu(fileName = TargetsRegistryRoutes.ServiceName,
        menuName = TargetsRegistryRoutes.ServicePath)]
    public class TargetRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private TargetRegistryGizmosConfig _gizmosConfig;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<TargetPlayerRegistry>()
                .WithParameter<ITargetRegistryGizmosConfig>(_gizmosConfig)
                .As<ITargetPlayerRegistry>();
        }
    }
}
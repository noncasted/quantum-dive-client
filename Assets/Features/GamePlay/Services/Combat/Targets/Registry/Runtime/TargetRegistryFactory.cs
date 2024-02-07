using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Combat.Targets.Registry.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Combat.Targets.Registry.Runtime
{
    [CreateAssetMenu(fileName = TargetsRegistryRoutes.ServiceName,
        menuName = TargetsRegistryRoutes.ServicePath)]
    public class TargetRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private TargetRegistryGizmosConfig _gizmosConfig;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<TargetPlayerRegistry>()
                .WithParameter<ITargetRegistryGizmosConfig>(_gizmosConfig)
                .As<ITargetPlayerRegistry>();
        }
    }
}
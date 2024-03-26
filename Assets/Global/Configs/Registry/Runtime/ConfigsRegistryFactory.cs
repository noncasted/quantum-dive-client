using Common.DataTypes.Runtime.Attributes;
using Cysharp.Threading.Tasks;
using Global.Configs.Registry.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Configs.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConfigsRegistryRoutes.ServiceName, menuName = ConfigsRegistryRoutes.ServicePath)]
    public class ConfigsRegistryFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [CreateSO] private ConfigsRegistry _registry;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            foreach (var source in _registry.Objects)
                source.CreateInstance(services);

            services.Register<Configs>()
                .As<IConfigs>()
                .AsCallbackListener();
        }
    }
}
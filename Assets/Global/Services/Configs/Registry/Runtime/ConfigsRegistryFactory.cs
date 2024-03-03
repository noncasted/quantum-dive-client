using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using Global.Configs.Abstract;
using Global.Configs.Registry.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Configs.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConfigsRegistryRoutes.ServiceName, menuName = ConfigsRegistryRoutes.ServicePath)]
    public class ConfigsRegistryFactory : ScriptableRegistry<ConfigSource>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            foreach (var source in Objects)
                source.CreateInstance(services);
            
            services.Register<ConfigsRegistry>()
                .As<IConfigsRegistry>()
                .AsCallbackListener();
        }
    }
}
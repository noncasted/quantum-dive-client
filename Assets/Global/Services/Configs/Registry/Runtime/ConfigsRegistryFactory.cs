﻿using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using Global.Configs.Abstract;
using Global.Configs.Registry.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Configs.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConfigsRegistryRoutes.ServiceName, menuName = ConfigsRegistryRoutes.ServicePath)]
    public class ConfigsRegistryFactory : ScriptableRegistry<ConfigSource>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            foreach (var source in Objects)
                source.CreateInstance(services);
            
            services.Register<ConfigsRegistry>()
                .As<IConfigsRegistry>()
                .AsCallbackListener();
        }
    }
}
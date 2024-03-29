﻿using Cysharp.Threading.Tasks;
using GamePlay.Services.Network.Objects.Factories.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Network.Objects.Factories.Registry
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkObjectFactoryRoutes.RegistryName,
        menuName = NetworkObjectFactoryRoutes.RegistryPath)]
    public class NetworkFactoriesRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NetworkFactoriesRegistry>()
                .As<INetworkFactoriesRegistry>()
                .AsCallbackListener();
        }
    }
}
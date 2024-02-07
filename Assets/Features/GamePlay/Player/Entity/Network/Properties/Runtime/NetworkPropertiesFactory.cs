﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Network.Properties.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Network.Properties.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkPropertiesRoutes.ServiceName,
        menuName = NetworkPropertiesRoutes.ServicePath)]
    public class NetworkPropertiesFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<NetworkPropertiesInjector>()
                .AsCallbackListener();
        }
    }
}
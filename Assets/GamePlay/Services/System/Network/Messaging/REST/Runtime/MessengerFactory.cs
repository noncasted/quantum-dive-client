﻿using Cysharp.Threading.Tasks;
using GamePlay.Services.Network.Messaging.REST.Common;
using GamePlay.Services.System.Network.Messaging.REST.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Network.Messaging.REST.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessengerRoutes.ServiceName, menuName = MessengerRoutes.ServicePath)]
    public class MessengerFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<Messenger>()
                .As<IMessenger>()
                .AsCallbackListener();

            services.Register<MessageDistributor>()
                .As<IMessageDistributor>();
        }
    }
}
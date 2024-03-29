﻿using Cysharp.Threading.Tasks;
using Global.Backend.Abstract;
using Global.Backend.Common;
using Global.Backend.Transactions;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Backend.Runtime
{

    [InlineEditor]
    [CreateAssetMenu(fileName = BackendRoutes.ServiceName, menuName = BackendRoutes.ServicePath)]
    public class BackendFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<BackendClient>()
                .As<IBackendClient>()
                .AsCallbackListener();

            services.Register<TransactionRunner>()
                .As<ITransactionRunner>();
        }
    }
}
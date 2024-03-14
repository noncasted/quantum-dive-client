﻿using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Global.System.ScopeDisposer.Common;
using Global.System.ScopeDisposer.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ScopeDisposer.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ScopeDisposerRoutes.ServiceName,
        menuName = ScopeDisposerRoutes.ServicePath)]
    public class ScopeDisposerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private ScopeDisposerLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<ScopeDisposerLogger>()
                .WithParameter(_logSettings);

            services.Register<ScopeDisposer>()
                .As<IScopeDisposer>();
        }
    }
}
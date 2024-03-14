﻿using Cysharp.Threading.Tasks;
using Global.UI.UiStateMachines.Abstract;
using Global.UI.UiStateMachines.Common;
using Global.UI.UiStateMachines.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.UiStateMachines.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UiStateMachineRouter.ServiceName,
        menuName = UiStateMachineRouter.ServicePath)]
    public class UiStateMachineFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private UiStateMachineLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<UiStateMachineLogger>()
                .WithParameter(_logSettings);

            services.Register<UiStateMachine>()
                .As<IUiStateMachine>();
        }
    }
}
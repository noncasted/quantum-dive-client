﻿using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Common;
using GamePlay.Enemies.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Enemies.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Components.StateMachines.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteStateMachineRoutes.ComponentName,
        menuName = RemoteStateMachineRoutes.ComponentPath)]
    public class RemoteStateMachineFactory : ScriptableObject, IEnemyComponentFactory
    {
        [SerializeField] private RemoteStateMachineLogSettings _logSettings;
        
        public void Create(IServiceCollection services, ICallbackRegistry callbacks)
        {
            services.Register<RemoteStateMachineLogger>()
                .WithParameter(_logSettings);
            
            services.Register<RemoteStateMachine>()
                .As<IRemoteStateMachine>()
                .As<IStateMachineSync>()
                .AsSelf();
        }
    }
}
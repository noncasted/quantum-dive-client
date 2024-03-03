﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Common;
using GamePlay.Enemy.Entity.Components.StateMachines.Remote.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.StateMachines.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RemoteStateMachineRoutes.ComponentName,
        menuName = RemoteStateMachineRoutes.ComponentPath)]
    public class RemoteStateMachineFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private RemoteStateMachineLogSettings _logSettings;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
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
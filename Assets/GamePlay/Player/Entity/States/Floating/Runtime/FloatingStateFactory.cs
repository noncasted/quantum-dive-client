﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Common;
using GamePlay.Player.Entity.States.Floating.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Floating.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = FloatingRoutes.StateName,
        menuName = FloatingRoutes.StatePath)]
    public class FloatingStateFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private PlayerStateDefinition[] _statesPriority;
        [SerializeField] private FloatingStateLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<FloatingStateLogger>()
                .WithParameter(_logSettings);

            services.Register<FloatingState>()
                .As<IFloatingState>()
                .As<IFloatingTransitionsRegistry>()
                .WithParameter(_statesPriority)
                .AsCallbackListener();
        }
    }
}
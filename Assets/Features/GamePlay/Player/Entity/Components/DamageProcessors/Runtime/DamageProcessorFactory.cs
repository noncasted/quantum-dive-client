﻿using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Components.DamageProcessors.Common;
using GamePlay.Player.Entity.Setup.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DamageProcessorRoutes.ComponentName,
        menuName = DamageProcessorRoutes.ComponentPath)]
    public class DamageProcessorFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private DamageProcessorConfigAsset _config;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<DamageProcessor>()
                .WithParameter(_config)
                .As<IDamageProcessor>()
                .AsCallbackListener();
        }
    }
}
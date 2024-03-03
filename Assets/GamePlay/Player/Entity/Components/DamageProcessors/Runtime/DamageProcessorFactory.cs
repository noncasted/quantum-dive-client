﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.DamageProcessors.Common;
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

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<DamageProcessor>()
                .WithParameter(_config)
                .As<IDamageProcessor>()
                .AsCallbackListener();
        }
    }
}
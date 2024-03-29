﻿using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.Runs.Remote;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RunRoutes.LocalName,
        menuName = RunRoutes.LocalPath)]
    public class LocalRunFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _runAnimation;
        [SerializeField] [Indent] private RunConfigAsset _config;
        [SerializeField] [Indent] private RunDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<RunInputSync>()
                .As<IRunInputSync>()
                .AsSelf();
            
            services.Register<RunConfig>()
                .WithParameter(_config)
                .As<IRunConfig>();

            var animation = _runAnimation.CreateAnimation();

            services.Register<RunInput>()
                .As<IRunInput>()
                .AsCallbackListener();

            services.Register<LocalRun>()
                .WithParameter(_definition)
                .WithParameter(animation)
                .AsCallbackListener();
        }
    }
}
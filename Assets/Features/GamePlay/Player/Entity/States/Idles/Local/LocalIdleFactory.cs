﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.States.Idles.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Idles.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdleRoutes.LocalName,
        menuName = IdleRoutes.LocalPath)]
    public class LocalIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private IdleAnimationFactory _animation;
        [SerializeField] [Indent] private IdleLogSettings _logSettings;
        [SerializeField] [Indent] private IdleDefinition _definition;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var animation = _animation.Create();

            services.Register<IdleLogger>()
                .WithParameter(_logSettings);

            services.Register<LocalIdle>()
                .As<IIdle>()
                .WithParameter(animation)
                .WithParameter(_definition);
        }
    }
}
﻿using Common.Tools.UniversalAnimators.Abstract;
using GamePlay.Player.Entity.States.Idles.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Idles.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = IdleRoutes.LocalName,
        menuName = IdleRoutes.LocalPath)]
    public class LocalIdleFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private BaseAnimationData _animation;
        [SerializeField] [Indent] private IdleDefinition _definition;

        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            var animation = _animation.CreateAnimation();

            services.Register<LocalIdle>()
                .As<IIdle>()
                .WithParameter(animation)
                .WithParameter(_definition);
        }
    }
}
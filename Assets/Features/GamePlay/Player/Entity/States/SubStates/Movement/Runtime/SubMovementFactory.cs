﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.States.Idles.Common;
using GamePlay.Player.Entity.States.Runs.Common;
using GamePlay.Player.Entity.States.SubStates.Movement.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SubMovementRoutes.StateName, menuName = SubMovementRoutes.StatePath)]
    public class SubMovementFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] [Indent] private RunAnimationFactory _runAnimation;
        [SerializeField] [Indent] private WalkAnimationFactory _walkAnimation;
        [SerializeField] [Indent] private IdleAnimationFactory _idleAnimation;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var runAnimation = _runAnimation.Create();
            var walkAnimation = _walkAnimation.Create();
            var idleAnimation = _idleAnimation.Create();
                        
            services.Register<SubMovement>()
                .As<ISubMovement>()
                .WithParameter(runAnimation)
                .WithParameter(walkAnimation)
                .WithParameter(idleAnimation);
        }
    }
}
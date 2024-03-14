﻿using System.Threading;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Async;
using Common.Tools.UniversalAnimators.Old.Animations.Implementations.Looped;
using Common.Tools.UniversalAnimators.Old.Animators.Runtime;
using Common.Tools.UniversalAnimators.Old.Updaters.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Views.Animators.Logs;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Animators.Runtime
{
    public class EnemyAnimator : IEnemyAnimator, IEntitySwitchListener
    {
        public EnemyAnimator(
            IAnimatorsUpdater animatorsUpdater,
            SpriteRenderer spriteRenderer,
            AnimatorLogger logger)
        {
            _animator = new UniversalAnimator(spriteRenderer);
            _animatorsUpdater = animatorsUpdater;
            _logger = logger;
        }

        private readonly IAnimatorsUpdater _animatorsUpdater;
        private readonly UniversalAnimator _animator;
        private readonly AnimatorLogger _logger;
        
        public void OnEnabled()
        {
           // _animatorsUpdater.Register(_animator);
        }

        public void OnDisabled()
        {
         //   _animatorsUpdater.Unregister(_animator);
        }
        
        public void PlayLooped(ILoopedAnimation animation)
        {
            _logger.OnLooped(animation.Data.Name);
            _animator.PlayLooped(animation);
        }

        public async UniTask PlayAsync(IAsyncAnimation animation, CancellationToken cancellationToken)
        {
            _logger.OnAsync(animation.Data.Name);
            await _animator.PlayAsync(animation, cancellationToken);
        }
    }
}
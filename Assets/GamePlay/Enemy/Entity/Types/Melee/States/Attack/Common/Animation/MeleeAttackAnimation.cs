using System;
using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.FrameProviders.Forward;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Cysharp.Threading.Tasks;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common.Animation
{
    public class MeleeAttackAnimation : AsyncAnimation
    {
        public MeleeAttackAnimation(
            ForwardFrameProvider frameProvider,
            AnimationData data,
            EnemyMeleeAttackEvent meleeAttackEvent) : base(frameProvider, data)
        {
            _onCanceled = OnCanceled;   
            
            AddEventListener(meleeAttackEvent, OnShootFrame);
        }

        private readonly Action _onCanceled;

        private UniTaskCompletionSource _completion;
        
        public async UniTask WaitAttackFrameAsync(CancellationToken cancellationToken)
        {
            _completion = new UniTaskCompletionSource();
            cancellationToken.Register(_onCanceled);

            await _completion.Task;
        }

        private void OnShootFrame()
        {
            _completion?.TrySetResult();
        }

        private void OnCanceled()
        {
            _completion.TrySetResult();
        }
    }
}
using System;
using System.Threading;
using Common.Tools.UniversalAnimators.Animations.Abstract;
using Common.Tools.UniversalAnimators.Animations.Implementations.Async;
using Cysharp.Threading.Tasks;

namespace GamePlay.Enemies.Types.Range.States.Shoot.Common
{
    public class ShootAnimation : AsyncAnimation
    {
        public ShootAnimation(
            IFrameProvider frameProvider,
            AnimationData data,
            EnemyShootEvent shootEvent) : base(frameProvider, data)
        {
            _onCanceled = OnCanceled;   
            
            AddEventListener(shootEvent, OnShootFrame);
        }

        private readonly Action _onCanceled;

        private UniTaskCompletionSource _completion;
        
        public async UniTask WaitShootFrameAsync(CancellationToken cancellationToken)
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
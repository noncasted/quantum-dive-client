using System.Threading;
using Animancer;
using Common.Tools.UniversalAnimators.Abstract;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Runtime
{
    public class EnhancedAnimator : IEnhancedAnimator
    {
        public EnhancedAnimator(AnimancerComponent animator)
        {
            _animator = animator;
        }

        private readonly AnimancerComponent _animator;

        public void PlayLooped(IAnimation animation)
        {
            var data = animation.Data;
            _animator.Play(data.Clip, data.FadeDuration);
        }

        public async UniTask PlayAsync(IAnimation animation, CancellationToken cancellationToken)
        {
            var data = animation.Data;
            var state = _animator.Play(data.Clip, data.FadeDuration, FadeMode.FromStart);
            
            var completion = new UniTaskCompletionSource();
            
            state.Events.OnEnd += OnEnd;

            cancellationToken.Register(OnCancelled);

            await completion.Task;
            
            state.Events.OnEnd -= OnEnd;

            return;

            void OnEnd()
            {
                completion.TrySetResult();
            }

            void OnCancelled()
            {
                state.Events.OnEnd -= OnEnd;
            }
        }
    }
}
using Common.Architecture.Lifetimes;
using Common.Tools.UniversalAnimators.Animators.Runtime;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Tests
{
    [DisallowMultipleComponent]
    public class UniversalAnimatorTestObject : MonoBehaviour
    {
        [SerializeField] private TestAnimationFactory _animationFactory;
        [SerializeField] private UniversalAnimatorBenchmarkUpdater _updater;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            var loopedAnimation = _animationFactory.Create();
            var universalAnimator = new UniversalAnimator(_spriteRenderer);

            loopedAnimation.TestEvent += OnEvent;

            _updater.Register(new Lifetime(), universalAnimator);
            
            universalAnimator.PlayLooped(loopedAnimation);

            void OnEvent()
            {
                Debug.Log("Event called");
            }
        }
    }
}
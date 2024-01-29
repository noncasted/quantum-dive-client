using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Player.UI.Overlay.Runtime.HealthBars
{
    public class HealthBarCell : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _fillTime = 1f;

        [SerializeField] private Image _fill;

        private CancellationTokenSource _cancellation;

        private void Awake()
        {
            _fill.fillAmount = 0f;
        }

        private void OnDisable()
        {
            Cancel();
        }

        public void Fill()
        {
            Cancel();

            _cancellation = new CancellationTokenSource();

            Animate(_cancellation.Token, 1f).Forget();
        }

        public void Release()
        {
            Cancel();

            _cancellation = new CancellationTokenSource();

            Animate(_cancellation.Token, 0f).Forget();
        }

        private void Cancel()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        private async UniTaskVoid Animate(CancellationToken cancellation, float target)
        {
            var start = _fill.fillAmount;
            var time = 0f;
            var progress = 0f;

            while (progress < 1f)
            {
                progress = time / _fillTime;
                var value = Mathf.Lerp(start, target, progress);
                _fill.fillAmount = value;

                time += Time.deltaTime;

                await UniTask.Yield(cancellation);
            }
        }
    }
}
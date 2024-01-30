using System.Threading;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.States.SubStates.Damaged.Common;
using GamePlay.Player.Entity.States.SubStates.Pushes.Runtime;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Local
{
    public class LocalDamaged : IDamaged, IEntitySwitchListener
    {
        public LocalDamaged(
            IPlayerSpriteMaterial spriteMaterial,
            ISubPush push,
            IEntityEvents events,
            IDamagedConfig config)
        {
            _spriteMaterial = spriteMaterial;
            _push = push;
            _events = events;
            _config = config;
        }

        private readonly IPlayerSpriteMaterial _spriteMaterial;
        private readonly ISubPush _push;
        private readonly IEntityEvents _events;
        private readonly IDamagedConfig _config;

        private CancellationTokenSource _cancellation;

        private static readonly int _flickProgressProperty = Shader.PropertyToID("_Progress");

        public void OnEnabled()
        {
        }

        public void OnDisabled()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        public void Enter(Vector2 direction, float force)
        {
            _events.ReplicateEvent(new PlayerDamagedEvent());

            Process(direction, force).Forget();
        }

        private async UniTaskVoid Process(Vector2 direction, float force)
        {
            _cancellation?.Cancel();
            _cancellation = new CancellationTokenSource();

            var distance = _config.BasePushDistance * force;
            var pushParams = new PushParams(_config.Time, distance, _config.PushCurve);

            var pushTask = _push.PushAsync(direction, pushParams, _cancellation.Token);
            var flickTask = FlickAsync(_config.Time, _config.FlickAmount, _cancellation.Token);

            await UniTask.WhenAll(pushTask, flickTask);
        }

        private async UniTask FlickAsync(float time, int amount, CancellationToken cancellation)
        {
            var count = 0;
            var delay = Mathf.CeilToInt(time * 1000 / amount);
            var isFlicked = false;

            var defaultMaterial = _spriteMaterial.Material;
            _spriteMaterial.SetMaterial(_config.Material);

            cancellation.Register(() =>
            {
                _spriteMaterial.SetMaterial(defaultMaterial);
            });

            while (count < amount)
            {
                isFlicked = !isFlicked;

                if (isFlicked == true)
                    _spriteMaterial.Material.SetFloat(_flickProgressProperty, 1f);
                else
                    _spriteMaterial.Material.SetFloat(_flickProgressProperty, 0f);

                count++;
                await UniTask.Delay(delay, cancellation);
            }

            _spriteMaterial.SetMaterial(defaultMaterial);
        }
    }
}
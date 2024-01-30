using System.Threading;
using Common.Architecture.Entities.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.States.SubStates.Damaged.Common;
using GamePlay.Player.Entity.States.SubStates.Damaged.Local;
using GamePlay.Player.Entity.Views.Sprites.Runtime;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Remote
{
    public class RemoteDamaged : IEntityAttachListener, IEntitySwitchListener
    {
        public RemoteDamaged(
            IPlayerSpriteMaterial spriteMaterial,
            IEntityEvents events,
            IDamagedConfig config)
        {
            _spriteMaterial = spriteMaterial;
            _events = events;
            _config = config;
        }

        private readonly IPlayerSpriteMaterial _spriteMaterial;
        private readonly IEntityEvents _events;
        private readonly IDamagedConfig _config;

        private CancellationTokenSource _cancellation;

        private static readonly int _flickProgressProperty = Shader.PropertyToID("_Progress");

        public void OnEntityAttached()
        {
            _events.ListenEvent<PlayerDamagedEvent>(OnDamaged);
        }

        public void OnEnabled()
        {

        }

        public void OnDisabled()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        private void OnDamaged(RagonPlayer player, PlayerDamagedEvent payload)
        {
            _cancellation = new CancellationTokenSource();

            Process(_cancellation.Token).Forget();
        }

        private async UniTaskVoid Process(CancellationToken cancellation)
        {
            var count = 0;
            var delay = Mathf.CeilToInt(_config.Time * 1000 / _config.FlickAmount);
            var isFlicked = false;

            var defaultMaterial = _spriteMaterial.Material;
            _spriteMaterial.SetMaterial(_config.Material);

            cancellation.Register(() =>
            {
                _spriteMaterial.SetMaterial(defaultMaterial);
            });

            while (count < _config.FlickAmount)
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
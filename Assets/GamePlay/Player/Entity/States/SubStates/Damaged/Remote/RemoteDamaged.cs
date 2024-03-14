using System.Threading;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.States.SubStates.Damaged.Common;
using GamePlay.Player.Entity.States.SubStates.Damaged.Local;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Remote
{
    public class RemoteDamaged : IEntitySwitchLifetimeListener, IEntityDisableListener
    {
        public RemoteDamaged(
            IEntityEvents events,
            IDamagedConfig config)
        {
            _events = events;
            _config = config;
        }

        private readonly IEntityEvents _events;
        private readonly IDamagedConfig _config;

        private CancellationTokenSource _cancellation;

        private static readonly int FlickProgressProperty = Shader.PropertyToID("_Progress");

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _events.ListenEvent<PlayerDamagedEvent>(lifetime, OnDamaged);
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
            //
            // var defaultMaterial = _spriteMaterial.Material;
            // _spriteMaterial.SetMaterial(_config.Material);
            //
            // cancellation.Register(() =>
            // {
            //     _spriteMaterial.SetMaterial(defaultMaterial);
            // });
            //
            // while (count < _config.FlickAmount)
            // {
            //     isFlicked = !isFlicked;
            //
            //     if (isFlicked == true)
            //         _spriteMaterial.Material.SetFloat(FlickProgressProperty, 1f);
            //     else
            //         _spriteMaterial.Material.SetFloat(FlickProgressProperty, 0f);
            //
            //     count++;
            //     await UniTask.Delay(delay, cancellation);
            // }
            //
            // _spriteMaterial.SetMaterial(defaultMaterial);
        }
    }
}
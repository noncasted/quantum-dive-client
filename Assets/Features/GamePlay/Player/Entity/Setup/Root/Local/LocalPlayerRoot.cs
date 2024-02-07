using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Equipment.Equipper.Local;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.States.None.Runtime;
using GamePlay.Player.Entity.States.Respawns.Local;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Root.Local
{
    public class LocalPlayerRoot : ILocalPlayerRoot, IEntityEnableListener
    {
        private LocalPlayerRoot(
            IRespawn respawn,
            INone none,
            IPlayerPosition position,
            IHealth health,
            IPlayerTransform transform,
            IEntityCallbacks callbacks,
            IEquipper equipper)
        {
            _respawn = respawn;
            _none = none;
            _position = position;
            _health = health;
            _transform = transform;
            _callbacks = callbacks;
            _equipper = equipper;
        }

        private readonly INone _none;
        private readonly IPlayerPosition _position;
        private readonly IHealth _health;
        private readonly IPlayerTransform _transform;
        private readonly IEntityCallbacks _callbacks;
        private readonly IEquipper _equipper;
        private readonly IRespawn _respawn;

        private bool _isActive;
        private ILifetime _lifetime;

        public IHealth Health => _health;
        public IPlayerPosition Position => _position;
        public IPlayerTransform Transform => _transform;
        public IEquipper Equipper => _equipper;
        public IEntityCallbacks Callbacks => _callbacks;

        public void OnEnabled()
        {
            _none.Enter();
        }

        public void Respawn()
        {
            _respawn.Enter();
        }

        public async UniTask Enable()
        {
            if (_isActive == true)
            {
                Debug.LogError("Player can't be enabled twice");
                return;
            }

            _isActive = true;

            if (_lifetime != null)
                await _lifetime.Terminate();

            _lifetime = new Lifetime();
            await _callbacks.RunEnable(_lifetime);
        }

        public async UniTask Disable()
        {
            if (_isActive == false)
            {
                Debug.LogError("Player can't be disabled twice");
                return;
            }

            _isActive = false;

            await _lifetime.Terminate();
            await _callbacks.RunDisable();
        }
    }
}
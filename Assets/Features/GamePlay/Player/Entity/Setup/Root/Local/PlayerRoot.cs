using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Equipment.Equipper.Local;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.States.None.Runtime;
using GamePlay.Player.Entity.States.Respawns.Local;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Root.Local
{
    public class PlayerRoot : IPlayerRoot
    {
        private PlayerRoot(
            IRespawn respawn,
            INone none,
            IPlayerPosition position,
            IHealth health,
            IPlayerTransformProvider transform,
            IPlayerObjectEventLoop objectEventLoop,
            IEquipper equipper)
        {
            Position = position;
            _respawn = respawn;
            _none = none;
            _health = health;
            Transform = transform;
            _objectEventLoop = objectEventLoop;
            Equipper = equipper;
        }

        private readonly INone _none;
        private readonly IHealth _health;
        private readonly IRespawn _respawn;

        private readonly IPlayerObjectEventLoop _objectEventLoop;
        private bool _isActive;

        public IHealth Health => _health;
        public IPlayerPosition Position { get; }
        public IPlayerTransformProvider Transform { get; }
        public IEquipper Equipper { get; }

        private void OnEnable()
        {
            if (_isActive == false)
                return;

            _objectEventLoop.InvokeEnable();
        }

        private void OnDisable()
        {
            _isActive = true;
            _objectEventLoop.InvokeDisable();
        }

        private void OnDestroy()
        {
            _objectEventLoop.InvokeDestroy();
        }

        public async UniTask OnBootstrapped()
        {
            _objectEventLoop.InvokeAwake();
            await _objectEventLoop.InvokeAsyncAwake();
            _objectEventLoop.InvokeEnable();
            _objectEventLoop.InvokeStart();

            _isActive = true;

            _none.Enter();
        }

        public void Respawn()
        {
            _respawn.Enter();
        }

        public void Enable()
        {
            if (_isActive == true)
            {
                Debug.LogError("Player can't be enabled twice");
                return;
            }

            _isActive = true;
            _objectEventLoop.InvokeEnable();
        }

        public void Disable()
        {
            if (_isActive == false)
            {
                Debug.LogError("Player can't be disabled twice");
                return;
            }

            _isActive = false;
            _objectEventLoop.InvokeDisable();
        }
    }
}
using Common.Architecture.Entities.Runtime.Callbacks;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Equipment.Equipper.Local;
using GamePlay.Player.Entity.States.None.Runtime;
using GamePlay.Player.Entity.States.Respawns.Local;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Root.Local
{
    public class LocalPlayerRoot : ILocalPlayerRoot, IEntityLoadedAsyncListener
    {
        private LocalPlayerRoot(
            IRespawn respawn,
            INone none,
            IPlayerPosition position,
            IHealth health,
            IPlayerTransformProvider transform,
            IEntityCallbacks callbacks,
            IEquipper equipper)
        {
            Position = position;
            _respawn = respawn;
            _none = none;
            _health = health;
            _callbacks = callbacks;
            Transform = transform;
            Equipper = equipper;
        }

        private readonly INone _none;
        private readonly IHealth _health;
        private readonly IEntityCallbacks _callbacks;
        private readonly IRespawn _respawn;

        private bool _isActive;

        public IHealth Health => _health;
        public IPlayerPosition Position { get; }
        public IPlayerTransformProvider Transform { get; }
        public IEquipper Equipper { get; }

        public async UniTask OnLoadedAsync()
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
            await _callbacks.Handlers[CallbackStage.Enable].Run();
        }

        public async UniTask Disable()
        {
            if (_isActive == false)
            {
                Debug.LogError("Player can't be disabled twice");
                return;
            }

            _isActive = false;
            await _callbacks.Handlers[CallbackStage.Disable].Run();
        }
    }
}
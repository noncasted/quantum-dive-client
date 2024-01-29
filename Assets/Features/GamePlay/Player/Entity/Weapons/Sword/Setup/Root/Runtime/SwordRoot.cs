using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime
{
    public class SwordRoot : IEquipment
    {
        public SwordRoot(
            IPlayerObjectEventLoop objectEventLoop,
            SwordSlotDefinition definition)
        {
            _objectEventLoop = objectEventLoop;
            _definition = definition;
        }

        private readonly IPlayerObjectEventLoop _objectEventLoop;
        private readonly SwordSlotDefinition _definition;

        private bool _isActive;

        public SlotDefinition Slot => _definition;

        public async UniTask OnBootstrapped()
        {
            _objectEventLoop.InvokeAwake();
            await _objectEventLoop.InvokeAsyncAwake();
            _objectEventLoop.InvokeStart();
        }

        public void Select()
        {
            if (_isActive == true)
            {
                Debug.LogError("Bow can't be enabled twice");
                return;
            }

            _isActive = true;
            _objectEventLoop.InvokeEnable();
        }

        public void Deselect()
        {
            if (_isActive == false)
            {
                Debug.LogError("Bow can't be disabled twice");
                return;
            }

            _isActive = false;
            _objectEventLoop.InvokeDisable();
        }
    }
}
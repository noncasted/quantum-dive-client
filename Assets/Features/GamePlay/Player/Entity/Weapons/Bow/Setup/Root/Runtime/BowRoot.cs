using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Equipment.Abstract.Definition;
using GamePlay.Player.Entity.Equipment.Slots.Storage.Abstract;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Views.GameObjects.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Root.Runtime
{
    public class BowRoot : IEquipment
    {
        public BowRoot(
            IPlayerObjectEventLoop objectEventLoop,
            BowSlotDefinition definition,
            IBowGameObject gameObject)
        {
            _objectEventLoop = objectEventLoop;
            _definition = definition;
            _gameObject = gameObject;
        }

        private readonly IPlayerObjectEventLoop _objectEventLoop;
        private readonly BowSlotDefinition _definition;
        private readonly IBowGameObject _gameObject;

        private bool _isActive;

        public SlotDefinition Slot => _definition;

        public async UniTask OnBootstrapped()
        {
            _objectEventLoop.InvokeAwake();
            await _objectEventLoop.InvokeAsyncAwake();
            _objectEventLoop.InvokeStart();
            
            _gameObject.Disable();
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
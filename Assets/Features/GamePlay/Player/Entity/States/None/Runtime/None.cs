using GamePlay.Player.Entity.Components.Equipment.Locker.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.None.Logs;
using GamePlay.Player.Entity.Views.Sprites.Runtime;

namespace GamePlay.Player.Entity.States.None.Runtime
{
    public class None : INone, IPlayerLocalState
    {
        public None(
            ILocalStateMachine stateMachine,
            ISpriteSwitcher spriteSwitcher,
            IEquipmentLocker locker,
            NoneLogger logger,
            NoneDefinition definition)
        {
            _stateMachine = stateMachine;
            _spriteSwitcher = spriteSwitcher;
            _locker = locker;
            _logger = logger;
            _definition = definition;
        }

        private readonly NoneDefinition _definition;
        private readonly IEquipmentLocker _locker;
        private readonly NoneLogger _logger;
        private readonly ISpriteSwitcher _spriteSwitcher;

        private readonly ILocalStateMachine _stateMachine;

        public PlayerStateDefinition Definition => _definition;
        
        public void Enter()
        {
            _locker.Lock();
            _spriteSwitcher.Disable(true);

            _stateMachine.Enter(this);

            _logger.OnEntered();
        }

        public void Break()
        {
            _locker.Unlock();
            _spriteSwitcher.Enable(true);

            _logger.OnExited();
        }
    }
}
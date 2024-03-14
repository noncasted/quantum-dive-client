using GamePlay.Player.Entity.Components.Equipment.Locker.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.None.Abstract;
using GamePlay.Player.Entity.States.None.Logs;

namespace GamePlay.Player.Entity.States.None.Runtime
{
    public class None : INone, IPlayerLocalState
    {
        public None(
            ILocalStateMachine stateMachine,
            IEquipmentLocker locker,
            NoneLogger logger,
            NoneDefinition definition)
        {
            _stateMachine = stateMachine;
            _locker = locker;
            _logger = logger;
            _definition = definition;
        }

        private readonly NoneDefinition _definition;
        private readonly IEquipmentLocker _locker;
        private readonly NoneLogger _logger;

        private readonly ILocalStateMachine _stateMachine;

        public PlayerStateDefinition Definition => _definition;
        
        public void Enter()
        {
            _locker.Lock();

            _stateMachine.Enter(this);

            _logger.OnEntered();
        }

        public void Break()
        {
            _locker.Unlock();

            _logger.OnExited();
        }
    }
}
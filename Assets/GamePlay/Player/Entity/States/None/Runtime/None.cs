using GamePlay.Player.Entity.Components.Equipment.Locker.Abstract;
using GamePlay.Player.Entity.Components.StateMachines.Local.Abstract;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.None.Abstract;

namespace GamePlay.Player.Entity.States.None.Runtime
{
    public class None : INone, IPlayerLocalState
    {
        public None(
            ILocalStateMachine stateMachine,
            IEquipmentLocker locker,
            NoneDefinition definition)
        {
            _stateMachine = stateMachine;
            _locker = locker;
            _definition = definition;
        }

        private readonly NoneDefinition _definition;
        private readonly IEquipmentLocker _locker;

        private readonly ILocalStateMachine _stateMachine;

        public PlayerStateDefinition Definition => _definition;
        
        public void Enter()
        {
            _locker.Lock();

            _stateMachine.Enter(this);
        }

        public void Break()
        {
            _locker.Unlock();
        }
    }
}
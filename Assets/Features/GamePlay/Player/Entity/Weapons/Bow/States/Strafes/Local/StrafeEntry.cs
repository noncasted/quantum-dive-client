using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver;
using GamePlay.Player.Entity.Weapons.Combo.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local
{
    public class StrafeEntry : IUpdatable, IFloatingTransition, IPlayerSwitchListener, IComboState
    {
        public StrafeEntry(
            IStrafeInputReceiver inputReceiver,
            ILocalStateMachine stateMachine,
            IComboStateMachine comboStateMachine,
            IFloatingTransitionsRegistry floatingTransitionsRegistry,
            IStrafe strafe,
            IUpdater updater,
            PlayerStateDefinition[] transitions)
        {
            _inputReceiver = inputReceiver;
            _stateMachine = stateMachine;
            _comboStateMachine = comboStateMachine;
            _floatingTransitionsRegistry = floatingTransitionsRegistry;
            _strafe = strafe;
            _updater = updater;
            _transitions = transitions;
        }

        private readonly IStrafeInputReceiver _inputReceiver;
        private readonly ILocalStateMachine _stateMachine;
        private readonly IComboStateMachine _comboStateMachine;
        private readonly IFloatingTransitionsRegistry _floatingTransitionsRegistry;
        private readonly IStrafe _strafe;
        private readonly IUpdater _updater;

        private readonly PlayerStateDefinition[] _transitions;

        public PlayerStateDefinition[] Transitions => _transitions;

        public void OnEnabled()
        {
            _floatingTransitionsRegistry.Register(_strafe.Definition, this);
            _comboStateMachine.Register(_strafe.Definition, this);

            _updater.Add(this);
        }

        public void OnDisabled()
        {
            _floatingTransitionsRegistry.Unregister(_strafe.Definition);
            _comboStateMachine.Unregister(_strafe.Definition);

            _updater.Remove(this);
        }

        public bool IsTransitionFromFloatingAvailable()
        {
            if (_inputReceiver.IsPerformed == false)
                return false;

            return true;
        }

        public bool IsTransitionToComboAvailable()
        {
            if (_inputReceiver.IsPerformed == false)
                return false;

            return true;
        }

        public void EnterFromFloating()
        {
            _strafe.Enter();
        }

        public void EnterCombo()
        {
            _strafe.Enter();
        }

        public void OnUpdate(float delta)
        {
            if (_inputReceiver.IsPerformed == false)
                return;

            if (_stateMachine.IsAvailable(_strafe.Definition) == false)
                return;

            _strafe.Enter();
        }
    }
}
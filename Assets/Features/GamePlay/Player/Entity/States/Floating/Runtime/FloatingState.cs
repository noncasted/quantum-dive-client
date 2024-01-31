using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Common;
using GamePlay.Player.Entity.States.Floating.Logs;
using GamePlay.Player.Entity.States.Idles.Local;

namespace GamePlay.Player.Entity.States.Floating.Runtime
{
    public class FloatingState :
        IFloatingState,
        IFloatingTransitionsRegistry,
        IEntitySwitchLifetimeListener
    {
        public FloatingState(
            IIdle idle,
            ILocalStateMachine stateMachine,
            PlayerStateDefinition[] statesPriority,
            FloatingStateLogger logger)
        {
            _idle = idle;
            _stateMachine = stateMachine;
            _statesPriority = statesPriority;

            _logger = logger;
        }

        private readonly IIdle _idle;
        private readonly ILocalStateMachine _stateMachine;

        private readonly FloatingStateLogger _logger;

        private readonly PlayerStateDefinition[] _statesPriority;
        private readonly Dictionary<PlayerStateDefinition, IFloatingTransition> _transitions = new();

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _stateMachine.Exited.Listen(lifetime, Enter);
        }
        
        public void Register(ILifetime lifetime, PlayerStateDefinition definition, IFloatingTransition transition)
        {
            _transitions.Add(definition, transition);

            lifetime.ListenTerminate(() => _transitions.Remove(definition));
        }

        public void Unregister(PlayerStateDefinition definition)
        {
            _transitions.Remove(definition);
        }

        public void Enter()
        {
            _logger.OnEntered();

            foreach (var definition in _statesPriority)
            {
                if (_transitions.ContainsKey(definition) == false)
                    continue;

                var transition = _transitions[definition];

                if (transition.IsTransitionFromFloatingAvailable() == false)
                    continue;

                transition.EnterFromFloating();
                return;
            }

            _idle.Enter();
        }
    }
}
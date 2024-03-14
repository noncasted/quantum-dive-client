using System.Collections.Generic;
using Internal.Scopes.Abstract.Lifetimes;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Combo.Runtime
{
    public class ComboStateMachine : IComboStateMachine
    {
        public ComboStateMachine(ILocalStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private readonly ILocalStateMachine _stateMachine;

        private readonly Dictionary<PlayerStateDefinition, IComboState> _states = new();

        public void Register(ILifetime lifetime, PlayerStateDefinition definition, IComboState state)
        {
            _states.Add(definition, state);

            lifetime.ListenTerminate(() => _states.Remove(definition));
        }

        public void TryTransitCombo(IPlayerLocalState from, PlayerStateDefinition[] transitions)
        {
            foreach (var definition in transitions)
            {
                if (_states.ContainsKey(definition) == false)
                {
                    Debug.LogError($"No state registered for: {definition.name}");
                    continue;
                }

                var transition = _states[definition];
                
                if (transition.IsTransitionToComboAvailable() == false)
                    continue;
                
                transition.EnterCombo();
                return;
            }
                
            _stateMachine.Exit(from);
        }
    }
}
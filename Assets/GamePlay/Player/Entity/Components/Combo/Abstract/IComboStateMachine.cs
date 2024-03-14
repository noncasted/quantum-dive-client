using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Player.Entity.Components.Combo.Runtime
{
    public interface IComboStateMachine
    {
        void Register(ILifetime lifetime, PlayerStateDefinition definition, IComboState state);
        void TryTransitCombo(IPlayerLocalState from, PlayerStateDefinition[] transitions);
    }
}
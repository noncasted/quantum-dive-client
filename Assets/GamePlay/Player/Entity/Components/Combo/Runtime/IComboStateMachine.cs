using Common.Architecture.Lifetimes;
using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.Combo.Runtime
{
    public interface IComboStateMachine
    {
        void Register(ILifetime lifetime, PlayerStateDefinition definition, IComboState state);
        void TryTransitCombo(IPlayerLocalState from, PlayerStateDefinition[] transitions);
    }
}
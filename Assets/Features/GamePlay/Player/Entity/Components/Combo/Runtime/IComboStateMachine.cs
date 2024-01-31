using GamePlay.Player.Entity.States.Abstract;
using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.Combo.Runtime
{
    public interface IComboStateMachine
    {
        void Register(PlayerStateDefinition definition, IComboState state);
        void Unregister(PlayerStateDefinition definition);
        void TryTransitCombo(IPlayerLocalState from, PlayerStateDefinition[] transitions);
    }
}
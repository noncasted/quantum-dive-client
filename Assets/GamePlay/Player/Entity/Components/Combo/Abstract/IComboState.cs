using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Components.Combo.Abstract
{   
    public interface IComboState
    {
        PlayerStateDefinition[] Transitions { get; }
        
        bool IsTransitionToComboAvailable();
        void EnterCombo();
    }
}   
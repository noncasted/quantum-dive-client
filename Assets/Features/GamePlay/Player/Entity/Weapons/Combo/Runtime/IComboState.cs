using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Weapons.Combo.Runtime
{   
    public interface IComboState
    {
        PlayerStateDefinition[] Transitions { get; }
        
        bool IsTransitionToComboAvailable();
        void EnterCombo();
    }
}   
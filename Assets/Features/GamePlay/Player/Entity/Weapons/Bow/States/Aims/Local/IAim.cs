using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Aims.Local
{
    public interface IAim
    {
        bool IsEntered { get; }
        PlayerStateDefinition Definition { get; }
        
        void Enter();
    }
}
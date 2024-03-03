using GamePlay.Player.Entity.States.Common;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Local
{
    public interface IStrafe
    {
        PlayerStateDefinition Definition { get; }

        void Enter();
    }
}
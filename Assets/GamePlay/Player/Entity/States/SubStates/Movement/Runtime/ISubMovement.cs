using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.States.SubStates.Movement.Runtime
{
    public interface ISubMovement
    {
        void Enter(bool playAnimations, float speed, MoveType moveType);
        void Exit();

        void SetAnimationRotation(PlayerOrientation orientation);
    }
}
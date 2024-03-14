namespace GamePlay.Player.Entity.States.SubStates.Movement.Abstract
{
    public interface ISubMovement
    {
        void Enter(bool playAnimations, float speed, MoveType moveType);
        void Exit();
    }
}
namespace GamePlay.Player.Entity.States.Floating.Runtime
{
    public interface IFloatingTransition
    {
        bool IsTransitionFromFloatingAvailable();
        
        void EnterFromFloating();
    }
}
namespace GamePlay.Player.Entity.States.Floating.Abstract
{
    public interface IFloatingTransition
    {
        bool IsTransitionFromFloatingAvailable();
        
        void EnterFromFloating();
    }
}
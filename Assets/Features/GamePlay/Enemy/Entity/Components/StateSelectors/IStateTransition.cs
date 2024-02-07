namespace GamePlay.Enemy.Entity.Components.StateSelectors
{
    public interface IStateTransition
    {
        bool IsAvailable();
        
        void Transit();
    }
}
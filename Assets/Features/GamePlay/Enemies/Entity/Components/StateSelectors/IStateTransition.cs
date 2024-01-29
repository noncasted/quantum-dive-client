namespace GamePlay.Enemies.Entity.Components.StateSelectors
{
    public interface IStateTransition
    {
        bool IsAvailable();
        
        void Transit();
    }
}
namespace GamePlay.Enemies.Entity.Setup.EventLoop
{
    public interface IEnemyEventLoop
    {
        void InvokeAwake();
        void InvokeEnable();
        void InvokeDisable();
        void InvokeEntityAttached();
    }
}
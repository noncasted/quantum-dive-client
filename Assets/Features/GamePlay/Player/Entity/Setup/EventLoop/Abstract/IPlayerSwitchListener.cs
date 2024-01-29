namespace GamePlay.Player.Entity.Setup.EventLoop.Abstract
{
    public interface IPlayerSwitchListener
    {
        void OnEnabled();
        void OnDisabled();
    }
}
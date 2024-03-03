using Common.Architecture.Lifetimes.Viewables;

namespace GamePlay.Player.Entity.Views.Hitboxes.Network
{
    public interface IHitboxSync
    {
        IViewableDelegate<bool> StateChanged { get; }

        void SendEnable();
        void SendDisable();
    }
}
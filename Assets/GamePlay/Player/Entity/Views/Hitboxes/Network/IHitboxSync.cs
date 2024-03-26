using Common.DataTypes.Runtime.Reactive;

namespace GamePlay.Player.Entity.Views.Hitboxes.Network
{
    public interface IHitboxSync
    {
        IViewableDelegate<bool> StateChanged { get; }

        void SendEnable();
        void SendDisable();
    }
}
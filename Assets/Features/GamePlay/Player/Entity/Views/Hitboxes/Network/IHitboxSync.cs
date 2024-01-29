using System;

namespace GamePlay.Player.Entity.Views.Hitboxes.Network
{
    public interface IHitboxSync
    {
        event Action<bool> StateChanged;

        void SendEnable();
        void SendDisable();
    }
}
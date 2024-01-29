using System;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Common
{
    public interface IHitboxStateSync
    {
        event Action<bool> StateChanged;

        void SendEnable();
        void SendDisable();
    }
}
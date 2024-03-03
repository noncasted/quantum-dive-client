using System;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Common
{
    public interface IHitboxStateSync
    {
        event Action<bool> StateChanged;

        void SendEnable();
        void SendDisable();
    }
}
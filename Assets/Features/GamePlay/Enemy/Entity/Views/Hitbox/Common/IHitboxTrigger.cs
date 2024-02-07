using System;
using GamePlay.Common.Damages;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Common
{
    public interface IHitboxTrigger
    {
        event Action<Damage> Triggered;
    }
}
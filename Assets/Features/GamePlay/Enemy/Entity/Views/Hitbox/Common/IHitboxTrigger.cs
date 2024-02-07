using System;
using GamePlay.Common.Damages;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Common
{
    public interface IHitboxTrigger
    {
        event Action<Damage> Triggered;
    }
}
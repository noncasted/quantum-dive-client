using System;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Local
{
    public interface IHitbox
    {
        Vector2 Position { get; }

        event Action<Damage> DamageReceived;

        void Enable();
        void Disable();
    }
}
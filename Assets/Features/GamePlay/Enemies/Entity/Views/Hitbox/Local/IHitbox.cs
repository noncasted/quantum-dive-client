using System;
using Common.Architecture.Lifetimes.Viewables;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Hitbox.Local
{
    public interface IHitbox
    {
        Vector2 Position { get; }

        IViewableDelegate<Damage> DamageReceived { get; }

        void Enable();
        void Disable();
    }
}
using Common.DataTypes.Reactive;
using GamePlay.Common.Damages;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Hitbox.Local
{
    public interface IHitbox
    {
        Vector3 Position { get; }

        IViewableDelegate<Damage> DamageReceived { get; }

        void Enable();
        void Disable();
    }
}
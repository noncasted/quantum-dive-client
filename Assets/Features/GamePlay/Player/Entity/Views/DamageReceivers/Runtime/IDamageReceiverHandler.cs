using System;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    public interface IDamageReceiverHandler
    {
        event Action<Damage> Damaged;

        void Enable();
        void Disable();
    }
}
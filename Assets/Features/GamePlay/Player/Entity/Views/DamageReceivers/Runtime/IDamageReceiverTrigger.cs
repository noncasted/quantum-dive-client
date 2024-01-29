using System;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    public interface IDamageReceiverTrigger
    {
        event Action<Damage> Triggered;

        void Enable();
        void Disable();
    }
}
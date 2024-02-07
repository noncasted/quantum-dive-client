using System;
using GamePlay.Common.Damages;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages
{
    public interface IDamageTrigger
    {
        event Action<IDamageReceiver> Triggered;

        void Enable();
        void Disable();
    }
}
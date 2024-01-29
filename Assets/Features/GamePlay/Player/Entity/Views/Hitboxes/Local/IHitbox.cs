using System;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.Hitboxes.Local
{
    public interface IHitbox
    {
        event Action<Damage> Damaged;
        
        void Enable();
        void Disable();
    }
}

using Common.DataTypes.Runtime.Reactive;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.Hitboxes.Local
{
    public interface IHitbox
    {
        IViewableDelegate<Damage> Damaged { get; }
        
        void Enable();
        void Disable();
    }
}

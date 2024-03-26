using Common.DataTypes.Runtime.Reactive;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Abstract
{
    public interface IDamageReceiverHandler
    {
        IViewableDelegate<Damage> Damaged { get; }

        void Enable();
        void Disable();
    }
}
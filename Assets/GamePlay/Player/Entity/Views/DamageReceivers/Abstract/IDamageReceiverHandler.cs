using Common.DataTypes.Reactive;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    public interface IDamageReceiverHandler
    {
        IViewableDelegate<Damage> Damaged { get; }

        void Enable();
        void Disable();
    }
}
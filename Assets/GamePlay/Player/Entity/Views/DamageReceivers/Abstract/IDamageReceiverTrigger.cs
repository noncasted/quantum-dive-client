using Common.DataTypes.Reactive;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Views.DamageReceivers.Runtime
{
    public interface IDamageReceiverTrigger
    {
        IViewableDelegate<Damage> Triggered { get; }

        void Enable();
        void Disable();
    }
}
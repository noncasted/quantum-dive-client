using GamePlay.Common.Damages;

namespace GamePlay.Projectiles.Entity.Views.Triggers
{
    public interface IProjectileTrigger
    {
        bool Triggered { get; }
        IDamageReceiver Receiver { get; }
    }
}
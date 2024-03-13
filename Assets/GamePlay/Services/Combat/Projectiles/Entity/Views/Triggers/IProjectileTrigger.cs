using GamePlay.Common.Damages;

namespace GamePlay.Services.Combat.Projectiles.Entity.Views.Triggers
{
    public interface IProjectileTrigger
    {
        bool Triggered { get; }
        IDamageReceiver Receiver { get; }
    }
}
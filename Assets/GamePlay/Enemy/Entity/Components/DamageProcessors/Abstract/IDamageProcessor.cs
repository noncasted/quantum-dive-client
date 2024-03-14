using GamePlay.Common.Damages;

namespace GamePlay.Enemy.Entity.Components.DamageProcessors.Runtime
{
    public interface IDamageProcessor
    {
        void ProcessDamage(Damage damage);
    }
}
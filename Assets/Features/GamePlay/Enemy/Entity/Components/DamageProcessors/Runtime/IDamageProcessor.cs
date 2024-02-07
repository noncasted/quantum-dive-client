using GamePlay.Common.Damages;

namespace GamePlay.Enemies.Entity.Components.DamageProcessors.Runtime
{
    public interface IDamageProcessor
    {
        void ProcessDamage(Damage damage);
    }
}
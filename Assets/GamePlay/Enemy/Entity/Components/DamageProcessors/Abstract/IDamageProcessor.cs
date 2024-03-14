using GamePlay.Common.Damages;

namespace GamePlay.Enemy.Entity.Components.DamageProcessors.Abstract
{
    public interface IDamageProcessor
    {
        void ProcessDamage(Damage damage);
    }
}
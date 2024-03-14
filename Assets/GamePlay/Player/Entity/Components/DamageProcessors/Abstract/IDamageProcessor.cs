using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Abstract
{
    public interface IDamageProcessor
    {
        void OnDamage(Damage damage);
    }
}
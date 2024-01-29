using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Components.DamageProcessors.Runtime
{
    public interface IDamageProcessor
    {
        void OnDamage(Damage damage);
    }
}
using GamePlay.Common.Damages;

namespace GamePlay.Hitboxes.Runtime
{
    public struct HitboxComponent
    {
        private IDamageReceiver _damageReceiver;

        public IDamageReceiver DamageReceiver => _damageReceiver;

        public void Construct(IDamageReceiver damageReceiver)
        {
            _damageReceiver = damageReceiver;
        }
    }
}
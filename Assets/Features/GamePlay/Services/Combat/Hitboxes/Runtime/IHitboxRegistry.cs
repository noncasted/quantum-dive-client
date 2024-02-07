using GamePlay.Common.Damages;

namespace GamePlay.Combat.Hitboxes.Runtime
{
    public interface IHitboxRegistry
    {
        void AddLocalPlayer(IDamageReceiver damageReceiver);
        void AddRemotePlayer(IDamageReceiver damageReceiver);
        void AddEnemy(IDamageReceiver damageReceiver);
        void Remove(IDamageReceiver damageReceiver);
    }
}
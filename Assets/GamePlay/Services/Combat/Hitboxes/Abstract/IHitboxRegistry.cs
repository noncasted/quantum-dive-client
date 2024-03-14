using GamePlay.Common.Damages;

namespace GamePlay.Services.Combat.Hitboxes.Abstract
{
    public interface IHitboxRegistry
    {
        void AddLocalPlayer(IDamageReceiver damageReceiver);
        void AddRemotePlayer(IDamageReceiver damageReceiver);
        void AddEnemy(IDamageReceiver damageReceiver);
        void Remove(IDamageReceiver damageReceiver);
    }
}
using UnityEngine;

namespace GamePlay.Common.Damages
{
    public interface IDamageReceiver
    {
        Vector3 Position { get; }
        void ReceiveDamage(Damage damage);
    }
}
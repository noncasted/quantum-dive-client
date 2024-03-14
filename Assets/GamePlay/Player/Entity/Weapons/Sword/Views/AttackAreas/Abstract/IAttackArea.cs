using System.Collections.Generic;
using GamePlay.Common.Damages;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Abstract
{
    public interface IAttackArea
    {
        IReadOnlyList<IDamageReceiver> GetDamageReceivers(float angle);
    }
}
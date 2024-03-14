using System.Collections.Generic;
using GamePlay.Common.Damages;
using GamePlay.Player.Entity.Components.Rotations.Local.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Abstract;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime
{
    public class TargetsSearcher : ITargetsSearcher
    {
        public TargetsSearcher(IAttackArea attackArea, IRotation rotation)
        {
            _attackArea = attackArea;
            _rotation = rotation;
        }
        
        private readonly IAttackArea _attackArea;
        private readonly IRotation _rotation;

        public IReadOnlyList<IDamageReceiver> Search(float angle)
        {
            var receivers = _attackArea.GetDamageReceivers(_rotation.Angle);

            return receivers;
        }
    }
}
using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Views.AttackAreas.Runtime
{
    [Serializable]
    public class AttackAreaConfig : IAttackAreaConfig
    {
        [SerializeField] private ContactFilter2D _filter;
        [SerializeField] private int _bufferSize;

        public ContactFilter2D Filter => _filter;
        public int BufferSize => _bufferSize;
    }
}
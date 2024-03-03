using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Shoot.Free
{
    [Serializable]
    public class ShootMoveConfig
    {
        [SerializeField] [Min(0f)] private float _speed;

        public float Speed => _speed;
    }
}
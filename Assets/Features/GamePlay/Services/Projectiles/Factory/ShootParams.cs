using System;
using UnityEngine;

namespace GamePlay.Projectiles.Factory
{
    [Serializable]
    public class ShootParams
    {
        public ShootParams(
            int damage,
            float pushForce,
            float speed,
            float scale,
            float radius)
        {
            _damage = damage;
            _pushForce = pushForce;
            _speed = speed;
            _scale = scale;
            _radius = radius;   
        }
        
        [SerializeField] private int _damage;
        [SerializeField] private float _pushForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _scale;
        [SerializeField] private float _radius;

        public int Damage => _damage;
        public float PushForce => _pushForce;
        public float Speed => _speed;
        public float Scale => _scale;
        public float Radius => _radius;
    }
}
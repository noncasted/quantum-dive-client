using Common.DataTypes.Network;
using GamePlay.Combat.Projectiles.Factory;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Network
{
    public class EnemyProjectileRequestEvent : IRagonEvent
    {
        public EnemyProjectileRequestEvent(
            int definitionId,
            Vector2 position,
            Vector2 direction,
            ShootParams parameters)
        {
            _definitionId = definitionId;
            _position = position;
            _direction = direction;
            _damage = parameters.Damage;
            _pushForce = parameters.PushForce;
            _speed = parameters.Speed;
            _scale = parameters.Scale;
            _radius = parameters.Radius;   
        }

        public EnemyProjectileRequestEvent()
        {
            
        }

        private static readonly NetworkIntCompressor _idCompressor = new(0, 100_000);
        private static readonly NetworkIntCompressor _damageCompressor = new(0, 100);
        private static readonly NetworkFloatCompressor _paramsCompressor = new(0, 100, 0.01f);
        
        private int _definitionId;
        private Vector2 _position;
        private Vector2 _direction;
        
        private int _damage;
        private float _pushForce;
        private float _speed;
        private float _scale;
        private float _radius;

        public int DefinitionId => _definitionId;
        public Vector2 Position => _position;
        public Vector2 Direction => _direction;

        public int Damage => _damage;
        public float PushForce => _pushForce;
        public float Speed => _speed;
        public float Scale => _scale;
        public float Radius => _radius;
        
        public void Serialize(RagonBuffer buffer)
        {
            _idCompressor.Write(buffer, _definitionId);

            buffer.WritePosition(_position);
            buffer.WriteDirection(_direction);
            
            _damageCompressor.Write(buffer, _damage);
            
            _paramsCompressor.Write(buffer, _pushForce);
            _paramsCompressor.Write(buffer, _speed);
            _paramsCompressor.Write(buffer, _scale);
            _paramsCompressor.Write(buffer, _radius);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            _definitionId = _idCompressor.Read(buffer);

            _position = buffer.ReadPosition();
            _direction = buffer.ReadDirection();

            _damage = _damageCompressor.Read(buffer);
            
            _pushForce = _paramsCompressor.Read(buffer);
            _speed = _paramsCompressor.Read(buffer);
            _scale = _paramsCompressor.Read(buffer);
            _radius = _paramsCompressor.Read(buffer);
        }
    }
}
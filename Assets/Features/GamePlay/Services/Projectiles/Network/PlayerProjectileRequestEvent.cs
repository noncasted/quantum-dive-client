using Common.DataTypes.Network;
using GamePlay.Projectiles.Factory;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Projectiles.Network
{
    public class PlayerProjectileRequestEvent : IRagonEvent
    {
        public PlayerProjectileRequestEvent(
            int definitionId,
            Vector2 position,
            Vector2 direction,
            ShootParams parameters)
        {
            _definitionId = definitionId;
            _position = position;
            _direction = direction;
            _speed = parameters.Speed;
            _scale = parameters.Scale;
            _radius = parameters.Radius;  
        }

        public PlayerProjectileRequestEvent()
        {
            
        }

        private static readonly NetworkIntCompressor _idCompressor = new(0, 100_000);
        private static readonly NetworkFloatCompressor _paramsCompressor = new(0, 100, 0.01f);
        
        private int _definitionId;
        private Vector2 _position;
        private Vector2 _direction;

        private float _speed;
        private float _scale;
        private float _radius;

        public int DefinitionId => _definitionId;
        public Vector2 Position => _position;
        public Vector2 Direction => _direction;

        public float Speed => _speed;
        public float Scale => _scale;
        public float Radius => _radius;
        
        public void Serialize(RagonBuffer buffer)
        {
            _idCompressor.Write(buffer, _definitionId);

            buffer.WritePosition(_position);
            buffer.WriteDirection(_direction);
            
            _paramsCompressor.Write(buffer, _speed);
            _paramsCompressor.Write(buffer, _scale);
            _paramsCompressor.Write(buffer, _radius);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            _definitionId = _idCompressor.Read(buffer);

            _position = buffer.ReadPosition();
            _direction = buffer.ReadDirection();

            _speed = _paramsCompressor.Read(buffer);
            _scale = _paramsCompressor.Read(buffer);
            _radius = _paramsCompressor.Read(buffer);
        }
    }
}
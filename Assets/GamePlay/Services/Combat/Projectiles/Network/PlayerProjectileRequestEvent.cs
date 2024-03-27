using GamePlay.Services.Projectiles.Factory;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Network
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

        }

        public void Deserialize(RagonBuffer buffer)
        {

        }
    }
}
using Common.DataTypes.Network;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Pool.Runtime
{
    public class EnemySpawnPayload : IRagonPayload
    {
        public EnemySpawnPayload(Vector2 position)
        {
            _position = position;
        }

        public EnemySpawnPayload()
        {
            
        }
        
        private Vector2 _position;

        public Vector2 Position => _position;
        
        public void Serialize(RagonBuffer buffer)
        {
            buffer.WriteVector(_position);
        }

        public void Deserialize(RagonBuffer buffer)
        {
            _position = buffer.ReadVector();
        }
    }
}
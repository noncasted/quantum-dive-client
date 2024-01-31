using Common.DataTypes.Network;
using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Player.Factory.Factory.Runtime
{
    public class PlayerSpawnPayload : IRagonPayload
    {
        public PlayerSpawnPayload(Vector2 position)
        {
            _position = position;
        }

        public PlayerSpawnPayload()
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
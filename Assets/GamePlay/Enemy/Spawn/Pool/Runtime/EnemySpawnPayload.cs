﻿using Ragon.Client;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Pool.Runtime
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
        }

        public void Deserialize(RagonBuffer buffer)
        {
        }
    }
}
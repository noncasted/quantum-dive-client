using GamePlay.Services.Projectiles.Registry.Definition;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Factory
{
    public struct ProjectileRequest
    {
        public ProjectileRequest(
            IProjectileDefinition definition,
            Vector3 position, 
            Vector3 direction, 
            ShootParams parameters)
        {
            Definition = definition;
            Position = position;
            Direction = direction;
            Parameters = parameters;
        }
        
        public readonly IProjectileDefinition Definition;
        public readonly Vector3 Position;
        public readonly Vector3 Direction;
        public readonly ShootParams Parameters;
    }
}
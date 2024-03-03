using GamePlay.Combat.Projectiles.Registry.Definition;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Factory
{
    public struct ProjectileRequest
    {
        public ProjectileRequest(
            IProjectileDefinition definition,
            Vector2 position, 
            Vector2 direction, 
            ShootParams parameters)
        {
            Definition = definition;
            Position = position;
            Direction = direction;
            Parameters = parameters;
        }
        
        public readonly IProjectileDefinition Definition;
        public readonly Vector2 Position;
        public readonly Vector2 Direction;
        public readonly ShootParams Parameters;
    }
}
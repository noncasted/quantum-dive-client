using GamePlay.Projectiles.Entity.Views.Facade;
using GamePlay.Projectiles.Registry.Definition;
using UnityEngine;

namespace GamePlay.Projectiles.Pool
{
    public interface IProjectilesPool
    {
        IProjectileView Get(IProjectileDefinition definition, Vector2 position);
    }
}
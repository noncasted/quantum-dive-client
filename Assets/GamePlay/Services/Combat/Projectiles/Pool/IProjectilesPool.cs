using GamePlay.Services.Projectiles.Entity.Views.Facade;
using GamePlay.Services.Projectiles.Registry.Definition;
using UnityEngine;

namespace GamePlay.Services.Projectiles.Pool
{
    public interface IProjectilesPool
    {
        IProjectileView Get(IProjectileDefinition definition, Vector3 position);
    }
}
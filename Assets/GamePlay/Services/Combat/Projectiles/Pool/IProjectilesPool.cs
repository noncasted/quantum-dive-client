using GamePlay.Combat.Projectiles.Entity.Views.Facade;
using GamePlay.Combat.Projectiles.Registry.Definition;
using UnityEngine;

namespace GamePlay.Combat.Projectiles.Pool
{
    public interface IProjectilesPool
    {
        IProjectileView Get(IProjectileDefinition definition, Vector3 position);
    }
}
using Common.Tools.ObjectsPools.Runtime.Abstract;
using GamePlay.Projectiles.Entity.Views.Facade;
using UnityEngine;

namespace GamePlay.Projectiles.Registry.Definition
{
    public class ProjectileObjectFactory : IObjectFactory<ProjectileView>
    {
        public ProjectileObjectFactory(
            ProjectileView prefab,
            Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        private readonly Transform _parent;

        private readonly ProjectileView _prefab;

        public ProjectileView Create(Vector2 position, float angle = 0)
        {
            var rotation = Quaternion.Euler(0f, 0f, angle);
            var projectile = Object.Instantiate(_prefab, position, rotation, _parent);

            return projectile;
        }
    }
}
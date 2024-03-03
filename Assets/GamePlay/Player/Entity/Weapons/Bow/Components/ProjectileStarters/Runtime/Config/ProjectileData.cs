using System;
using GamePlay.Combat.Projectiles.Registry.Definition;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config
{
    [Serializable]
    public class ProjectileData
    {
        [SerializeField] private ProjectileDefinition _definition;
        [SerializeField] private Sprite _preview;

        public IProjectileDefinition Definition => _definition;
        public Sprite Preview => _preview;
    }
}
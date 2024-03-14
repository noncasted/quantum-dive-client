using GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common;
using GamePlay.Projectiles.Factory;
using GamePlay.Projectiles.Registry.Definition;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyShootRoutes.ConfigName,
        menuName = EnemyShootRoutes.ConfigPath)]
    public class ShootConfig : ScriptableObject, IShootConfig
    {
        [SerializeField] private ProjectileDefinition _definition;
        [SerializeField] private ShootParams _params;
        
        [SerializeField] [Min(0f)] private float _range;
        [SerializeField] [Min(0f)] private float _rate;
        
        public IProjectileDefinition Definition => _definition;
        public ShootParams Params => _params;

        public float Range => _range;
        public float Rate => _rate;
    }
}
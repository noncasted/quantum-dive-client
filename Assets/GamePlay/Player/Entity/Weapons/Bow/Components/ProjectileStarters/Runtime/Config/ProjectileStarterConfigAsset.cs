using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Common;
using GamePlay.Projectiles.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.ProjectileStarters.Runtime.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ProjectileStarterRoutes.ConfigName,
        menuName = ProjectileStarterRoutes.ConfigPath)]
    public class ProjectileStarterConfigAsset : ScriptableObject
    {
        [SerializeField] [Indent] private float _scale;
        [SerializeField] [Indent] private float _radius;
        [SerializeField] [Indent] private ShootParams _params;
        [SerializeField] [Indent] private ProjectileData _data;
        
        public float Scale => _scale;
        public float Radius => _radius;

        public ProjectileData Data => _data;
    }
}
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
        [SerializeField] [Indent] private ShootParams _params;
        [SerializeField] [Indent] private ProjectileData _data;

        public ShootParams Params => _params;
        public ProjectileData Data => _data;
    }
}
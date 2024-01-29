using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Common
{
    public class TargetSearcherRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "TargetSearcher";
        public const string ComponentPath = EnemyAssetsPaths.System + "TargetSearcher/Component";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "TargetSearcher";
        public const string ConfigPath = EnemyAssetsPaths.System + "TargetSearcher/Config";
        
        public const string GizmosConfigName = EnemyAssetsPrefixes.Config + "TargetSearcherGizmos";
        public const string GizmosConfigPath = EnemyAssetsPaths.System + "TargetSearcher/GizmosConfig";
    }
}
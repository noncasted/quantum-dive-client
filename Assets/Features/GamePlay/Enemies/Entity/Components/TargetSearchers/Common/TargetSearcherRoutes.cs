using Features.GamePlay.Enemies.Entity.Components.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.TargetSearchers.Common
{
    public class TargetSearcherRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "TargetSearcher";
        public const string ComponentPath = EnemyComponentsRoutes.Root + "TargetSearcher/Component";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "TargetSearcher";
        public const string ConfigPath = EnemyComponentsRoutes.Root + "TargetSearcher/Config";
        
        public const string GizmosConfigName = EnemyAssetsPrefixes.Config + "TargetSearcherGizmos";
        public const string GizmosConfigPath = EnemyComponentsRoutes.Root + "TargetSearcher/GizmosConfig";
    }
}
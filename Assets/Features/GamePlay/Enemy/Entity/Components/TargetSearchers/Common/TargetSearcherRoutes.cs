using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Components.Common;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Common
{
    public class TargetSearcherRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "TargetSearcher";
        public const string ComponentPath = EnemyComponentsRoutes.Root + "TargetSearcher/Component";
        
        public const string ConfigName = EnemyEntityPrefixes.Config + "TargetSearcher";
        public const string ConfigPath = EnemyComponentsRoutes.Root + "TargetSearcher/Config";
        
        public const string GizmosConfigName = EnemyEntityPrefixes.Config + "TargetSearcherGizmos";
        public const string GizmosConfigPath = EnemyComponentsRoutes.Root + "TargetSearcher/GizmosConfig";
    }
}
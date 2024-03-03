using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Components.Common;

namespace GamePlay.Enemy.Entity.Components.Health.Common
{
    public class EnemyHealthRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "Health";
        public const string ComponentPath = EnemyComponentsRoutes.Root + "Health/Component";
        
        public const string ConfigName = EnemyEntityPrefixes.Config + "Health";
        public const string ConfigPath = EnemyComponentsRoutes.Root + "Health/Config";
    }
}
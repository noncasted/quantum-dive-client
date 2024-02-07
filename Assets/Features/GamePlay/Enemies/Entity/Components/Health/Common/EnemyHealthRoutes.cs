using GamePlay.Enemies.Entity.Components.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Components.Health.Common
{
    public class EnemyHealthRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "Health";
        public const string ComponentPath = EnemyComponentsRoutes.Root + "Health/Component";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Health";
        public const string ConfigPath = EnemyComponentsRoutes.Root + "Health/Config";
    }
}
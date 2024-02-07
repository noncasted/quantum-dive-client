using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.Types.Range.Common;

namespace GamePlay.Enemies.Entity.Types.Range.States.Shoot.Common
{
    public class EnemyShootRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Shoot_Local";
        public const string LocalPath = EnemyRangeRoutes.Root + "Shoot/Local";

        public const string RemoteName = EnemyAssetsPrefixes.State + "Shoot_Remote";
        public const string RemotePath = EnemyRangeRoutes.Root + "Shoot/Remote";

        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Shoot";
        public const string DefinitionPath = EnemyRangeRoutes.Root + "Shoot/Definition";

        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Shoot";
        public const string AnimationPath = EnemyRangeRoutes.Root + "Shoot/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Shoot";
        public const string ConfigPath = EnemyRangeRoutes.Root + "Shoot/Config";
    }
}
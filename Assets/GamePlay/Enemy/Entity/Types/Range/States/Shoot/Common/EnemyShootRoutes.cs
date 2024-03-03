using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Types.Range.Common;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Common
{
    public class EnemyShootRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Shoot_Local";
        public const string LocalPath = EnemyRangeRoutes.Root + "Shoot/Local";

        public const string RemoteName = EnemyEntityPrefixes.State + "Shoot_Remote";
        public const string RemotePath = EnemyRangeRoutes.Root + "Shoot/Remote";

        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Shoot";
        public const string DefinitionPath = EnemyRangeRoutes.Root + "Shoot/Definition";

        public const string AnimationName = EnemyEntityPrefixes.Animation + "Shoot";
        public const string AnimationPath = EnemyRangeRoutes.Root + "Shoot/Animation";
        
        public const string ConfigName = EnemyEntityPrefixes.Config + "Shoot";
        public const string ConfigPath = EnemyRangeRoutes.Root + "Shoot/Config";
    }
}
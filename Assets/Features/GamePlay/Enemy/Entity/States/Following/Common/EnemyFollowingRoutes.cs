using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.States.Common;

namespace GamePlay.Enemies.Entity.States.Following.Common
{
    public class EnemyFollowingRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Following_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Following/Local";
        
        public const string RemoteName = EnemyEntityPrefixes.State + "Following_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Following/Remote";
        
        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Following";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Following/Definition";
        
        public const string AnimationName = EnemyEntityPrefixes.Animation + "Following";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Following/Animation";
    }
}
using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.States.Common;

namespace GamePlay.Enemies.Entity.States.Idle.Common
{
    public class EnemyIdleRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Idle_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Idle/Local";
        
        public const string RemoteName = EnemyEntityPrefixes.State + "Idle_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Idle/Remote";
        
        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Idle";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Idle/Definition";
        
        public const string AnimationName = EnemyEntityPrefixes.Animation + "Idle";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Idle/Animation";
    }
}
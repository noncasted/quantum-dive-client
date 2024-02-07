using Features.GamePlay.Enemies.Entity.States.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.Idle.Common
{
    public class EnemyIdleRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Idle_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Idle/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Idle_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Idle/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Idle";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Idle/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Idle";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Idle/Animation";
    }
}
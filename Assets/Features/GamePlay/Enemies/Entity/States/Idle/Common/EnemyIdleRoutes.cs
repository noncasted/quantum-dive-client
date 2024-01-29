using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.Idle.Common
{
    public class EnemyIdleRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Idle_Local";
        public const string LocalPath = EnemyAssetsPaths.States + "Idle/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Idle_Remote";
        public const string RemotePath = EnemyAssetsPaths.States + "Idle/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Idle";
        public const string DefinitionPath = EnemyAssetsPaths.States + "Idle/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Idle";
        public const string AnimationPath = EnemyAssetsPaths.States + "Idle/Animation";
    }
}
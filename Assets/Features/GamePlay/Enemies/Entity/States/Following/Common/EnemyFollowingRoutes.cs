using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.Following.Common
{
    public class EnemyFollowingRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Following_Local";
        public const string LocalPath = EnemyAssetsPaths.States + "Following/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Following_Remote";
        public const string RemotePath = EnemyAssetsPaths.States + "Following/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Following";
        public const string DefinitionPath = EnemyAssetsPaths.States + "Following/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Following";
        public const string AnimationPath = EnemyAssetsPaths.States + "Following/Animation";
    }
}
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.Death.Common
{
    public class EnemyDeathRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Death_Local";
        public const string LocalPath = EnemyAssetsPaths.States + "Death/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Death_Remote";
        public const string RemotePath = EnemyAssetsPaths.States + "Death/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Death";
        public const string DefinitionPath = EnemyAssetsPaths.States + "Death/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Death";
        public const string AnimationPath = EnemyAssetsPaths.States + "Death/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Death";
        public const string ConfigPath = EnemyAssetsPaths.States + "Death/Config";
    }
}
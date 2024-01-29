using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.Damaged.Common
{
    public class EnemyDamagedRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Damaged_Local";
        public const string LocalPath = EnemyAssetsPaths.States + "Damaged/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Damaged_Remote";
        public const string RemotePath = EnemyAssetsPaths.States + "Damaged/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Damaged";
        public const string DefinitionPath = EnemyAssetsPaths.States + "Damaged/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Damaged";
        public const string AnimationPath = EnemyAssetsPaths.States + "Damaged/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Damaged";
        public const string ConfigPath = EnemyAssetsPaths.States + "Damaged/Config";
    }
}
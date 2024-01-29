using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Types.Range.States.Shoot.Common
{
    public class EnemyShootRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Shoot_Local";
        public const string LocalPath = EnemyAssetsPaths.States + "Shoot/Local";

        public const string RemoteName = EnemyAssetsPrefixes.State + "Shoot_Remote";
        public const string RemotePath = EnemyAssetsPaths.States + "Shoot/Remote";

        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Shoot";
        public const string DefinitionPath = EnemyAssetsPaths.States + "Shoot/Definition";

        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Shoot";
        public const string AnimationPath = EnemyAssetsPaths.States + "Shoot/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Shoot";
        public const string ConfigPath = EnemyAssetsPaths.States + "Shoot/Config";
    }
}
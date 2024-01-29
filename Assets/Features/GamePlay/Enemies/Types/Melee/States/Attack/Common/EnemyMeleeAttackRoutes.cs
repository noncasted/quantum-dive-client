using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Common
{
    public class EnemyMeleeAttackRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Attack_Local";
        public const string LocalPath = EnemyAssetsPaths.States + "Attack/Local";

        public const string RemoteName = EnemyAssetsPrefixes.State + "Attack_Remote";
        public const string RemotePath = EnemyAssetsPaths.States + "Attack/Remote";

        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Attack";
        public const string DefinitionPath = EnemyAssetsPaths.States + "Attack/Definition";

        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Attack";
        public const string AnimationPath = EnemyAssetsPaths.States + "Attack/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Attack";
        public const string ConfigPath = EnemyAssetsPaths.States + "Attack/Config";

        public const string GizmosConfigName = EnemyAssetsPrefixes.Config + "Attack_Gizmos";
        public const string GizmosConfigPath = EnemyAssetsPaths.States + "Attack/GizmosConfig";
    }
}
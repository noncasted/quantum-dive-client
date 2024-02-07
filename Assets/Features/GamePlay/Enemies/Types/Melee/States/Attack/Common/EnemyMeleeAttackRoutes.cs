using Features.GamePlay.Enemies.Types.Melee.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Common
{
    public class EnemyMeleeAttackRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Attack_Local";
        public const string LocalPath = EnemyMeleeRoutes.Root + "Attack/Local";

        public const string RemoteName = EnemyAssetsPrefixes.State + "Attack_Remote";
        public const string RemotePath = EnemyMeleeRoutes.Root + "Attack/Remote";

        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Attack";
        public const string DefinitionPath = EnemyMeleeRoutes.Root + "Attack/Definition";

        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Attack";
        public const string AnimationPath = EnemyMeleeRoutes.Root + "Attack/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Attack";
        public const string ConfigPath = EnemyMeleeRoutes.Root + "Attack/Config";

        public const string GizmosConfigName = EnemyAssetsPrefixes.Config + "Attack_Gizmos";
        public const string GizmosConfigPath = EnemyMeleeRoutes.Root + "Attack/GizmosConfig";
    }
}
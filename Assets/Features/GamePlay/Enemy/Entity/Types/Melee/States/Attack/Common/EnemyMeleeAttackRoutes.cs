using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Types.Melee.Common;

namespace GamePlay.Enemy.Entity.Types.Melee.States.Attack.Common
{
    public class EnemyMeleeAttackRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Attack_Local";
        public const string LocalPath = EnemyMeleeRoutes.Root + "Attack/Local";

        public const string RemoteName = EnemyEntityPrefixes.State + "Attack_Remote";
        public const string RemotePath = EnemyMeleeRoutes.Root + "Attack/Remote";

        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Attack";
        public const string DefinitionPath = EnemyMeleeRoutes.Root + "Attack/Definition";

        public const string AnimationName = EnemyEntityPrefixes.Animation + "Attack";
        public const string AnimationPath = EnemyMeleeRoutes.Root + "Attack/Animation";
        
        public const string ConfigName = EnemyEntityPrefixes.Config + "Attack";
        public const string ConfigPath = EnemyMeleeRoutes.Root + "Attack/Config";

        public const string GizmosConfigName = EnemyEntityPrefixes.Config + "Attack_Gizmos";
        public const string GizmosConfigPath = EnemyMeleeRoutes.Root + "Attack/GizmosConfig";
    }
}
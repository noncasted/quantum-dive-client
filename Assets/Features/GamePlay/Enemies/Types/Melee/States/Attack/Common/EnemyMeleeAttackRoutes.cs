using Features.GamePlay.Enemies.Entity.States.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Types.Melee.States.Attack.Common
{
    public class EnemyMeleeAttackRoutes
    {
        private const string Root = EnemyStatesRoutes.Root + "Types/Melee/";
        
        public const string LocalName = EnemyAssetsPrefixes.State + "Attack_Local";
        public const string LocalPath = Root + "Attack/Local";

        public const string RemoteName = EnemyAssetsPrefixes.State + "Attack_Remote";
        public const string RemotePath = Root + "Attack/Remote";

        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Attack";
        public const string DefinitionPath = Root + "Attack/Definition";

        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Attack";
        public const string AnimationPath = Root + "Attack/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Attack";
        public const string ConfigPath = Root + "Attack/Config";

        public const string GizmosConfigName = EnemyAssetsPrefixes.Config + "Attack_Gizmos";
        public const string GizmosConfigPath = Root + "Attack/GizmosConfig";
    }
}
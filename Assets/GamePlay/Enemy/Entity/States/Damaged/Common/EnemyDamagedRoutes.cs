using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.States.Common;

namespace GamePlay.Enemy.Entity.States.Damaged.Common
{
    public class EnemyDamagedRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Damaged_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Damaged/Local";
        
        public const string RemoteName = EnemyEntityPrefixes.State + "Damaged_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Damaged/Remote";
        
        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Damaged";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Damaged/Definition";
        
        public const string AnimationName = EnemyEntityPrefixes.Animation + "Damaged";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Damaged/Animation";
        
        public const string ConfigName = EnemyEntityPrefixes.Config + "Damaged";
        public const string ConfigPath = EnemyStatesRoutes.Root + "Damaged/Config";
    }
}
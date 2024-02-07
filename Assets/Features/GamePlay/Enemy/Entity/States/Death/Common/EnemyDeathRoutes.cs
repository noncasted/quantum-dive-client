using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.States.Common;

namespace GamePlay.Enemy.Entity.States.Death.Common
{
    public class EnemyDeathRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Death_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Death/Local";
        
        public const string RemoteName = EnemyEntityPrefixes.State + "Death_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Death/Remote";
        
        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Death";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Death/Definition";
        
        public const string AnimationName = EnemyEntityPrefixes.Animation + "Death";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Death/Animation";
    }
}
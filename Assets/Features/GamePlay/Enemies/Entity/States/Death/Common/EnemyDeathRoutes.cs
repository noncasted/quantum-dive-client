using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.States.Common;

namespace GamePlay.Enemies.Entity.States.Death.Common
{
    public class EnemyDeathRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Death_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Death/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Death_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Death/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Death";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Death/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Death";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Death/Animation";
    }
}
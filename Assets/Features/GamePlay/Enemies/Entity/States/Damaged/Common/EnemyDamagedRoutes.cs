using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.States.Common;

namespace GamePlay.Enemies.Entity.States.Damaged.Common
{
    public class EnemyDamagedRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Damaged_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Damaged/Local";
        
        public const string RemoteName = EnemyAssetsPrefixes.State + "Damaged_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Damaged/Remote";
        
        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Damaged";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Damaged/Definition";
        
        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Damaged";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Damaged/Animation";
        
        public const string ConfigName = EnemyAssetsPrefixes.Config + "Damaged";
        public const string ConfigPath = EnemyStatesRoutes.Root + "Damaged/Config";
    }
}
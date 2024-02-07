using Features.GamePlay.Enemies.Entity.States.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.States.Respawn.Common
{
    public class EnemyRespawnRoutes
    {
        public const string LocalName = EnemyAssetsPrefixes.State + "Respawn_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Respawn/Local";

        public const string RemoteName = EnemyAssetsPrefixes.State + "Respawn_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Respawn/Remote";

        public const string DefinitionName = EnemyAssetsPrefixes.Definition + "Respawn";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Respawn/Definition";

        public const string AnimationName = EnemyAssetsPrefixes.Animation + "Respawn";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Respawn/Animation";
    }
}
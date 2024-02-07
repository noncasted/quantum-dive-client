using GamePlay.Enemies.Entity.Setup.Paths;
using GamePlay.Enemies.Entity.States.Common;

namespace GamePlay.Enemies.Entity.States.Respawn.Common
{
    public class EnemyRespawnRoutes
    {
        public const string LocalName = EnemyEntityPrefixes.State + "Respawn_Local";
        public const string LocalPath = EnemyStatesRoutes.Root + "Respawn/Local";

        public const string RemoteName = EnemyEntityPrefixes.State + "Respawn_Remote";
        public const string RemotePath = EnemyStatesRoutes.Root + "Respawn/Remote";

        public const string DefinitionName = EnemyEntityPrefixes.Definition + "Respawn";
        public const string DefinitionPath = EnemyStatesRoutes.Root + "Respawn/Definition";

        public const string AnimationName = EnemyEntityPrefixes.Animation + "Respawn";
        public const string AnimationPath = EnemyStatesRoutes.Root + "Respawn/Animation";
    }
}
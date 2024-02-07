using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Setup.Config.Common
{
    public class PlayerConfigRoutes
    {
        public const string LocalName = PlayerEntityPrefixes.Config + "Local";
        public const string LocalPath = PlayerEntityRoutes.Root + "Config/Local";
        
        public const string RemoteName = PlayerEntityPrefixes.Config + "Remote";
        public const string RemotePath = PlayerEntityRoutes.Root + "Config/Remote";
    }
}
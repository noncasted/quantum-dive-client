using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Setup.Root.Common
{
    public class PlayerRootRoutes
    {
        private const string Paths = PlayerEntityRoutes.Root + "Root/";

        public const string LocalPath = Paths + "Local";
        public const string LocalName = PlayerEntityPrefixes.Component + "Root_Local";

        public const string RemotePath = Paths + "Remote";
        public const string RemoteName = PlayerEntityPrefixes.Component + "Root_Remote";
    }
}
using GamePlay.Player.Entity.Common.Routes;

namespace GamePlay.Player.Entity.Components.Root.Common
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
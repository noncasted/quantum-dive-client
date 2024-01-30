using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Setup.Root.Common
{
    public class PlayerRootRoutes
    {
        private const string Paths = PlayerAssetsPaths.Root + "Root/";

        public const string LocalPath = Paths + "Local";
        public const string LocalName = PlayerAssetsPrefixes.Component + "Root_Local";

        public const string RemotePath = Paths + "Remote";
        public const string RemoteName = PlayerAssetsPrefixes.Component + "Root_Remote";
    }
}
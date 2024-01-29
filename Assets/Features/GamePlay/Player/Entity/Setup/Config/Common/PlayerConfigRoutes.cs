using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Setup.Config.Common
{
    public class PlayerConfigRoutes
    {
        public const string LocalName = PlayerAssetsPrefixes.Config + "Local";
        public const string LocalPath = PlayerAssetsPaths.Root + "Config/Local";
        
        public const string RemoteName = PlayerAssetsPrefixes.Config + "Remote";
        public const string RemotePath = PlayerAssetsPaths.Root + "Config/Remote";
    }
}
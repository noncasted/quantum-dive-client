using GamePlay.Player.Entity.Network.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Network.Properties.Common
{
    public class NetworkPropertiesRoutes
    {
        public const string ServiceName = PlayerEntityPrefixes.Component + "Properties";
        public const string ServicePath = PlayerNetworkRoutes.Root + "Properties";
    }
}
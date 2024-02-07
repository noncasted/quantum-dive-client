using GamePlay.Player.Entity.Common.Routes;
using GamePlay.Player.Entity.Network.Common;

namespace GamePlay.Player.Entity.Network.Properties.Common
{
    public class NetworkPropertiesRoutes
    {
        public const string ServiceName = PlayerEntityPrefixes.Component + "Properties";
        public const string ServicePath = PlayerNetworkRoutes.Root + "Properties";
    }
}
using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Network.Common;

namespace GamePlay.Enemy.Entity.Network.Properties.Common
{
    public class NetworkPropertiesRoutes
    {
        public const string ServiceName = EnemyEntityPrefixes.Component + "Properties";
        public const string ServicePath = EnemyNetworkRoutes.Root + "Properties";
    }
}
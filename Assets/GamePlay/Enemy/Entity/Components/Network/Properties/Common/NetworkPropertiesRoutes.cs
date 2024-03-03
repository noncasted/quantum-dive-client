using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Components.Network.Common;

namespace GamePlay.Enemy.Entity.Components.Network.Properties.Common
{
    public class NetworkPropertiesRoutes
    {
        public const string ServiceName = EnemyEntityPrefixes.Component + "Properties";
        public const string ServicePath = EnemyNetworkRoutes.Root + "Properties";
    }
}
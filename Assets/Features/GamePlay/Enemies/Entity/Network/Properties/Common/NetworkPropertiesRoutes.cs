using Features.GamePlay.Enemies.Entity.Network.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Network.Properties.Common
{
    public class NetworkPropertiesRoutes
    {
        public const string ServiceName = EnemyAssetsPrefixes.Component + "Properties";
        public const string ServicePath = EnemyNetworkRoutes.Root + "Properties";
    }
}
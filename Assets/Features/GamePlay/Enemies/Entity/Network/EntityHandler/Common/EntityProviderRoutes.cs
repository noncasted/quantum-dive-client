using Features.GamePlay.Enemies.Entity.Network.Common;
using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Network.EntityHandler.Common
{
    public class EntityProviderRoutes
    {
        public const string ComponentName = EnemyAssetsPrefixes.Component + "EntityProvider";
        public const string ComponentPath = EnemyNetworkRoutes.Root + "EntityProvider";
    }
}
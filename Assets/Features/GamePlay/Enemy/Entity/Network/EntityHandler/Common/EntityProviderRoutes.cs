using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Network.Common;

namespace GamePlay.Enemy.Entity.Network.EntityHandler.Common
{
    public class EntityProviderRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "EntityProvider";
        public const string ComponentPath = EnemyNetworkRoutes.Root + "EntityProvider";
    }
}
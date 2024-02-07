using GamePlay.Enemy.Entity.Common.Routes;
using GamePlay.Enemy.Entity.Components.Network.Common;

namespace GamePlay.Enemy.Entity.Components.Network.EntityHandler.Common
{
    public class EntityProviderRoutes
    {
        public const string ComponentName = EnemyEntityPrefixes.Component + "EntityProvider";
        public const string ComponentPath = EnemyNetworkRoutes.Root + "EntityProvider";
    }
}
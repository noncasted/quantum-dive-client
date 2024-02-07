using GamePlay.Player.Entity.Network.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Network.EntityHandler.Common
{
    public class EntityHandlerRoutes
    {
        private const string Paths = PlayerNetworkRoutes.Root + "Entity";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = PlayerEntityPrefixes.Component + "EntityHandler";
    }
}
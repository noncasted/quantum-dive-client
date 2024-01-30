using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Network.EntityHandler.Common
{
    public class EntityHandlerRoutes
    {
        private const string Paths = PlayerAssetsPaths.Root + "Network/";

        public const string ServicePath = Paths + "Service";
        public const string ServiceName = PlayerAssetsPrefixes.Component + "EntityHandler";
    }
}
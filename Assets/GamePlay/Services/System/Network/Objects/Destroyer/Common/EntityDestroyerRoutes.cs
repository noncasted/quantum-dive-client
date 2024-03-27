using GamePlay.Services.Network.Common;

namespace GamePlay.Services.Network.Objects.Destroyer.Common
{
    public class EntityDestroyerRoutes
    {
        public const string ServiceName = GamePlayNetworkPrefixes.Service + "EntityDestroyer";
        public const string ServicePath = GamePlayNetworkRoutes.Root + "EntityDestroyer";
    }
}
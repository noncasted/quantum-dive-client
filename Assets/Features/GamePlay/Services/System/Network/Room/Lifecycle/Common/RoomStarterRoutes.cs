using GamePlay.System.Network.Common;

namespace GamePlay.System.Network.Room.Lifecycle.Common
{
    public class RoomStarterRoutes
    {
        public const string ServiceName = GamePlayNetworkPrefixes.Service + "RoomStarter";
        public const string ServicePath = GamePlayNetworkRoutes.Root + "RoomStarter/Service";
        
        public const string MockName = GamePlayNetworkPrefixes.Service + "Mock_RoomStarter";
        public const string MockPath = GamePlayNetworkRoutes.Root + "RoomStarter/Mock";
    }
}
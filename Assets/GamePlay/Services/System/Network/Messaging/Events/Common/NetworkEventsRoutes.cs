using GamePlay.Services.Network.Common;

namespace GamePlay.Services.Network.Messaging.Events.Common
{
    public class NetworkEventsRoutes
    {
        public const string ServiceName = GamePlayNetworkPrefixes.Service + "Events";
        public const string ServicePath = GamePlayNetworkRoutes.Root + "Events/Service";

        public const string LogsName = GamePlayNetworkPrefixes.Logs + "Events";
        public const string LogsPath = GamePlayNetworkRoutes.Root + "Events/Logs";   
    }
}
using GamePlay.System.Network.Common;

namespace GamePlay.System.Network.Messaging.REST.Common
{
    public class MessengerRoutes
    {
        public const string ServiceName = GamePlayNetworkPrefixes.Service + "Messeges";
        public const string ServicePath = GamePlayNetworkRoutes.Root + "Messeges/Service";

        public const string LogsName = GamePlayNetworkPrefixes.Logs + "Messeges";
        public const string LogsPath = GamePlayNetworkRoutes.Root + "Messeges/Logs";
    }
}
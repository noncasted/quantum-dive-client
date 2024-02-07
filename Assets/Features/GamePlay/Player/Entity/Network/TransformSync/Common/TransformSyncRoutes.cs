using GamePlay.Player.Entity.Network.Common;
using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Views.Transforms.Remote.Common
{
    public class TransformSyncRoutes
    {
        public const string ServiceName = PlayerEntityPrefixes.Component + "Network_Transform";
        public const string ServicePath = PlayerNetworkRoutes.Root + "Transform/Component";
        
        public const string LogsName = PlayerEntityPrefixes.Logs + "Network_Transform";
        public const string LogsPath = PlayerNetworkRoutes.Root + "Transform/Logs";
    }
}
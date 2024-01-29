using GamePlay.Player.Entity.Setup.Path;

namespace GamePlay.Player.Entity.Views.Transforms.Remote.Common
{
    public class TransformSyncRoutes
    {
        public const string ServiceName = PlayerAssetsPrefixes.Component + "Network_Transform";
        public const string ServicePath = PlayerAssetsPaths.Root + "Network/Sync/Transform/Component";
        
        public const string LogsName = PlayerAssetsPrefixes.Logs + "Network_Transform";
        public const string LogsPath = PlayerAssetsPaths.Root + "Network/Sync/Transform/Logs";
    }
}
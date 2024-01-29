using GamePlay.Enemies.Entity.Setup.Paths;

namespace GamePlay.Enemies.Entity.Views.Transforms.Remote.Common
{
    public class TransformSyncRoutes
    {
        public const string ServiceName = EnemyAssetsPrefixes.Component + "Network_Transform";
        public const string ServicePath = EnemyAssetsPaths.Root + "Network/Sync/Transform/Component";
        
        public const string LogsName = EnemyAssetsPrefixes.Logs + "Network_Transform";
        public const string LogsPath = EnemyAssetsPaths.Root + "Network/Sync/Transform/Logs";
    }
}
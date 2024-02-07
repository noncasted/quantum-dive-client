using GamePlay.Enemy.Entity.Common.Routes;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Common
{
    public class TransformSyncRoutes
    {
        public const string ServiceName = EnemyEntityPrefixes.Component + "Network_Transform";
        public const string ServicePath = EnemyEntityRoutes.Root + "Network/Sync/Transform/Component";
        
        public const string LogsName = EnemyEntityPrefixes.Logs + "Network_Transform";
        public const string LogsPath = EnemyEntityRoutes.Root + "Network/Sync/Transform/Logs";
    }
}
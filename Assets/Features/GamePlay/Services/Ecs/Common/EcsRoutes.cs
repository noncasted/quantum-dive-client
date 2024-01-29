using GamePlay.Common.Paths;

namespace GamePlay.Ecs.Common
{
    public static class EcsRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Ecs/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Ecs";
    }
}
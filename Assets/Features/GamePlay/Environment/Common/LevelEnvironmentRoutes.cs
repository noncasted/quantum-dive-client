using GamePlay.Common.Paths;

namespace GamePlay.Environment.Common
{
    public static class LevelEnvironmentRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Environment/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Environment";

        public const string MockPath = _paths + "Mock";
        public const string MockName = GamePlayAssetsPrefixes.Service + "EnvironmentMock";
    }
}
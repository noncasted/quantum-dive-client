using GamePlay.Common.Routes;

namespace GamePlay.Environment.Common
{
    public static class LevelEnvironmentRoutes
    {
        private const string _paths = GamePlayRoutes.Root + "Environment/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayPrefixes.Service + "Environment";
    }
}
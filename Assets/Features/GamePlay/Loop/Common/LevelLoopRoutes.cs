using GamePlay.Common.Routes;

namespace GamePlay.Loop.Common
{
    public static class LevelLoopRoutes
    {
        private const string _paths = GamePlayRoutes.Root + "Loop/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayPrefixes.Service + "Loop";

        public const string LogsPath = _paths + "Logs";
        public const string LogsName = GamePlayPrefixes.Logs + "Loop";
    }
}
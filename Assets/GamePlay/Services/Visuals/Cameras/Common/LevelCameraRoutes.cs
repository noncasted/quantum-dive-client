using GamePlay.Services.Common.Routes;

namespace GamePlay.Services.Cameras.Common
{
    public static class LevelCameraRoutes
    {
        private const string Root = GamePlayServicesRoutes.Root + "LevelCamera/";

        public const string ServicePath = Root + "Service";
        public const string ServiceName = GamePlayServicesPrefixes.Service + "CameraUtils";

        public const string ConfigPath = Root + "Config";
        public const string ConfigName = GamePlayServicesPrefixes.Config + "LevelCamera";

        public const string LogsPath = Root + "Logger";
        public const string LogsName = GamePlayServicesPrefixes.Logs + "LevelCamera";
    }
}
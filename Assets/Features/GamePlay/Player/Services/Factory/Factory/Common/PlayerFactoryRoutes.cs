using GamePlay.Common.Paths;

namespace GamePlay.Player.Factory.Factory.Common
{
    public class PlayerFactoryRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Player/Services/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "Factory";

        public const string LogsPath = _paths + "Logs";
        public const string LogsName = GamePlayAssetsPrefixes.Logs + "Factory";
    }
}
using GamePlay.Player.Services.Common;

namespace GamePlay.Player.Services.Factory.Factory.Common
{
    public class PlayerFactoryRoutes
    {
        private const string Root = PlayerServicesRoutes.Root + "Factory/";

        public const string ServicePath = Root + "Service";
        public const string ServiceName = PlayerServicesPrefixes.Service + "Factory";

        public const string LogsPath = Root + "Logs";
        public const string LogsName = PlayerServicesPrefixes.Logs + "Factory";
    }
}
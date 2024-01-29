using GamePlay.Common.Paths;

namespace GamePlay.Player.Services.Provider.Common
{
    public static class PlayerProviderRoutes
    {
        private const string _paths = GamePlayAssetsPaths.Root + "Player/Services/Provider/";

        public const string ServicePath = _paths + "Service";
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "PlayerProvider";
    }
}
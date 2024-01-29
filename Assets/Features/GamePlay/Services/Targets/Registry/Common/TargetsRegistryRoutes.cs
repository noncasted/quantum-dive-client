using GamePlay.Common.Paths;

namespace GamePlay.Targets.Registry.Common
{
    public class TargetsRegistryRoutes
    {
        public const string ServiceName = GamePlayAssetsPrefixes.Service + "TargetRegistry";
        public const string ServicePath = GamePlayAssetsPaths.Root + "TargetsRegistry/Serivce";
        
        public const string ConfigName = GamePlayAssetsPrefixes.Config + "TargetRegistry";
        public const string ConfigPath = GamePlayAssetsPaths.Root + "TargetsRegistry/Config";
    }
}
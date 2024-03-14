using GamePlay.Network.Common;

namespace GamePlay.Network.Objects.Factories.Common
{
    public class NetworkObjectFactoryRoutes
    {
        public const string RegistryPath = GamePlayNetworkRoutes.Root + "ObjectsFactoriesRegistry";
        public const string RegistryName = GamePlayNetworkPrefixes.Service + "ObjectsFactoriesRegistry";
        
        public const string DynamicFactoryPath = GamePlayNetworkRoutes.Root + "DynamicFactory";
        public const string DynamicFactoryName = GamePlayNetworkPrefixes.Service + "DynamicFactory";
    }
}
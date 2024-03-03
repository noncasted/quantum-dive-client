using Common.Architecture.Lifetimes;
using Global.Network.Objects.Factories.Abstract;

namespace GamePlay.System.Network.Objects.Factories.Registry
{
    public interface INetworkFactoriesRegistry
    {
        ushort Register(IEntityFactory factory, ILifetime lifetime);
    }
}
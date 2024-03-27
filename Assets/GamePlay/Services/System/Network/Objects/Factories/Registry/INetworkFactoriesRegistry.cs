using Global.Network.Objects.Factories.Abstract;
using Internal.Scopes.Abstract.Lifetimes;

namespace GamePlay.Services.Network.Objects.Factories.Registry
{
    public interface INetworkFactoriesRegistry
    {
        ushort Register(IEntityFactory factory, ILifetime lifetime);
    }
}
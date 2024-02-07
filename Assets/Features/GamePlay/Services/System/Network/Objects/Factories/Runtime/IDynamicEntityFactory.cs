using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.System.Network.Objects.Factories.Runtime
{
    public interface IDynamicEntityFactory
    {
        RagonEntity Create(ushort type);
        UniTask Send(RagonEntity entity, IRagonPayload payload);
    }
}
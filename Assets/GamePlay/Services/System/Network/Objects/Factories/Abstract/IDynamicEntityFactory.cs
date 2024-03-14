using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Services.System.Network.Objects.Factories.Abstract
{
    public interface IDynamicEntityFactory
    {
        RagonEntity Create(ushort type);
        UniTask Send(RagonEntity entity, IRagonPayload payload);
    }
}
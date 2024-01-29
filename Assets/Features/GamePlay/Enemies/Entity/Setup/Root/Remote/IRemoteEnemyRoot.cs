using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Enemies.Entity.Setup.Root.Remote
{
    public interface IRemoteEnemyRoot : IPoolObject
    {
        UniTask OnBootstrapped();

        void OnBeforeAttach(RagonEntity entity);
        void OnAttached();
        void Enable();
        void Disable();
    }
}
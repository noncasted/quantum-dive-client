using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using Ragon.Client;

namespace GamePlay.Enemies.Entity.Setup.Root.Local
{
    public interface ILocalEnemyRoot : IPoolObject
    {
        UniTask OnBootstrapped();
        void OnBeforeAttach(RagonEntity entity);

        UniTask OnAttached();
        void Enable();
        void Disable();
    }
}
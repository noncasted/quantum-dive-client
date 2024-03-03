using Cysharp.Threading.Tasks;

namespace GamePlay.Enemy.Entity.Common.Definition.Root
{
    public interface ILocalEnemyRoot : IEnemyRoot
    {
        UniTask Respawn();
    }
}
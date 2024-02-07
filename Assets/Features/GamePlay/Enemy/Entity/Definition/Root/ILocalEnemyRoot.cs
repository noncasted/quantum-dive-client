using Cysharp.Threading.Tasks;

namespace GamePlay.Enemy.Entity.Definition.Root
{
    public interface ILocalEnemyRoot : IEnemyRoot
    {
        UniTask Respawn();
    }
}
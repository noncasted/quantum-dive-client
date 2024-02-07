using Cysharp.Threading.Tasks;

namespace GamePlay.Enemies.Entity.Definition.Root
{
    public interface ILocalEnemyRoot : IEnemyRoot
    {
        UniTask Respawn();
    }
}
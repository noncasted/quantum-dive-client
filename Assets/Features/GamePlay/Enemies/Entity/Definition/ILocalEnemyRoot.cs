using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Setup.Root.Abstract;

namespace GamePlay.Enemies.Entity.Setup.Root.Local
{
    public interface ILocalEnemyRoot : IEnemyRoot
    {
        UniTask Respawn();
    }
}
using Cysharp.Threading.Tasks;

namespace GamePlay.Enemy.Entity.States.Respawn.Local
{
    public interface IRespawn
    {
        UniTask Enter();
    }
}
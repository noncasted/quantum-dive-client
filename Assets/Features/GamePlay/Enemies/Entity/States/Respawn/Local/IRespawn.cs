using Cysharp.Threading.Tasks;

namespace GamePlay.Enemies.Entity.States.Respawn.Local
{
    public interface IRespawn
    {
        UniTask Enter();
    }
}
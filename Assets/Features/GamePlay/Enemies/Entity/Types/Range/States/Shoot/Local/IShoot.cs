using Cysharp.Threading.Tasks;
using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Entity.Types.Range.States.Shoot.Local
{
    public interface IShoot
    {
        UniTask Shoot(ISearchableTarget target);
    }
}
using Cysharp.Threading.Tasks;
using GamePlay.Services.Combat.Targets.Registry.Abstract;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    public interface IShoot
    {
        UniTask Shoot(ISearchableTarget target);
    }
}
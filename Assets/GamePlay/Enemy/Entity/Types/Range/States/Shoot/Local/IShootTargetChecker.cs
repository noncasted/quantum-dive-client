using GamePlay.Services.Combat.Targets.Registry.Abstract;

namespace GamePlay.Enemy.Entity.Types.Range.States.Shoot.Local
{
    public interface IShootTargetChecker
    {
        bool IsAvailable(ISearchableTarget target);
        void OnShoot();
    }
}
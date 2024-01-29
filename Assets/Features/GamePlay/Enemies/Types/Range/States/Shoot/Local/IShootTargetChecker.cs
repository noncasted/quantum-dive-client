using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Types.Range.States.Shoot.Local
{
    public interface IShootTargetChecker
    {
        bool IsAvailable(ISearchableTarget target);
        void OnShoot();
    }
}
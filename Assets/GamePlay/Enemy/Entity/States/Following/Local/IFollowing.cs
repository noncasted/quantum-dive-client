using GamePlay.Combat.Targets.Registry.Runtime;

namespace GamePlay.Enemy.Entity.States.Following.Local
{
    public interface IFollowing
    {
        void Follow(ISearchableTarget target);
    }
}
using GamePlay.Services.Combat.Targets.Registry.Abstract;

namespace GamePlay.Enemy.Entity.States.Following.Local
{
    public interface IFollowing
    {
        void Follow(ISearchableTarget target);
    }
}
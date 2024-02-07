using GamePlay.Targets.Registry.Runtime;

namespace GamePlay.Enemies.Entity.States.Following.Local
{
    public interface IFollowing
    {
        void Follow(ISearchableTarget target);
    }
}
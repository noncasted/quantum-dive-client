using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler
{
    public interface IEntityProvider
    {
        int Id { get; }
        bool IsAttached { get; }
        bool IsMine { get; }

        void Construct(RagonEntity entity);
    }
}
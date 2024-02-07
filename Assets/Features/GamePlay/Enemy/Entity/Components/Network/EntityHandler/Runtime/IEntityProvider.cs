using Ragon.Client;

namespace GamePlay.Enemy.Entity.Components.Network.EntityHandler.Runtime
{
    public interface IEntityProvider
    {
        int Id { get; }
        bool IsAttached { get; }
        bool IsMine { get; }

        void Construct(RagonEntity entity);
    }
}
using System;
using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler
{
    public interface IEntityProvider
    {
        int Id { get; }
        bool IsAttached { get; }
        bool IsMine { get; }

        event Action Detached;

        void SetEntity(RagonEntity entity);
        void DestroyEntity();
    }
}
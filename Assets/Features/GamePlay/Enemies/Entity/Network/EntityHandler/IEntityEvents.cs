using System;
using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler
{
    public interface IEntityEvents
    {
        public void ListenEvent<TEvent>(Action<RagonPlayer, TEvent> callback) where TEvent : IRagonEvent, new();
        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new();
    }
}
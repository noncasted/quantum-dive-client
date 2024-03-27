using System;
using Ragon.Client;

namespace GamePlay.Services.Network.Room.Entities.Entity
{
    public interface IStaticEntity
    {
        public void ListenEvent<TEvent>(Action<RagonPlayer, TEvent> callback) where TEvent : IRagonEvent, new();
        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new();
    }
}
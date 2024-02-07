using System;
using Ragon.Client;

namespace Menu.Services.Network.Entity.Runtime
{
    public interface IMenuEntity
    {
        public void ListenEvent<TEvent>(Action<RagonPlayer, TEvent> callback) where TEvent : IRagonEvent, new();
        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new();
        
        void CreateEntity();
        void AddProperty(RagonProperty property);

        event Action Created;
    }
}
using System;
using Internal.Scopes.Abstract.Lifetimes;
using Ragon.Client;

namespace GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract
{
    public interface IEntityEvents
    {
        public void ListenEvent<TEvent>(
            ILifetime lifetime,
            Action<RagonPlayer, TEvent> callback)
            where TEvent : IRagonEvent, new();

        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new();
    }
}
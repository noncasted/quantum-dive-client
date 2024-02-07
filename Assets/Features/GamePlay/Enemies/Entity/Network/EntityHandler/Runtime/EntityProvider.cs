using System;
using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Lifetimes;
using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler
{
    public class EntityProvider : IEntityProvider, IPropertyBinder, IEntityEvents, IEntitySwitchLifetimeListener
    {
        private RagonEntity _entity;
        private readonly List<Action> _eventListeners = new();

        public int Id => _entity.Id;
        public bool IsAttached => _entity.IsAttached;
        public bool IsMine => _entity.HasAuthority;

        public void Construct(RagonEntity entity)
        {
            _entity = entity;
        }

        public void OnSwitchLifetimeCreated(ILifetime lifetime)
        {
            _entity.Attached += OnAttached;
            
            lifetime.ListenTerminate(() =>
            {
                _entity.Attached -= OnAttached;
                _entity = null;
            });
        }

        public void BindProperty(RagonProperty property)
        {
            if (_entity.IsAttached == true)
                throw new ArgumentException($"Entity: {_entity.Id} is already attached");

            _entity.State.AddProperty(property);
        }

        public void ListenEvent<TEvent>(ILifetime lifetime, Action<RagonPlayer, TEvent> callback)
            where TEvent : IRagonEvent, new()
        {
            if (_entity.IsAttached == true)
                Listen();
            else
                _eventListeners.Add(Listen);

            return;

            void Listen()
            {
                if (lifetime.IsTerminated == true)
                    return;

                var listener = _entity.OnEvent(callback);
                lifetime.ListenTerminate(() => listener.Dispose());
            }
        }

        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(data);
        }

        private void OnAttached(RagonEntity entity)
        {
            foreach (var listener in _eventListeners)
                listener?.Invoke();
        }
    }
}
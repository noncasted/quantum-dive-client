using System;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Ragon.Client;

namespace GamePlay.Player.Entity.Network.EntityHandler.Runtime
{
    public class EntityProvider : IEntityProvider, IPropertyBinder, IEntityEvents, IEntitySwitchListener
    {
        public EntityProvider(RagonEntity entity)
        {
            _entity = entity;
        }

        private readonly RagonEntity _entity;

        public int Id => _entity.Id;
        public bool IsAttached => _entity.IsAttached;
        public bool IsMine => _entity.HasAuthority;

        public void OnEnabled()
        {
            _entity.Attached += OnAttached;
        }

        public void OnDisabled()
        {
            _entity.Attached -= OnAttached;
        }


        public void BindProperty(RagonProperty property)
        {
            if (_entity.IsAttached == true)
                throw new ArgumentException($"Entity: {_entity.Id} is already attached");

            _entity.State.AddProperty(property);
        }

        public void ListenEvent<TEvent>(Action<RagonPlayer, TEvent> callback) where TEvent : IRagonEvent, new()
        {
            _entity.OnEvent(callback);
        }

        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(data);
        }

        private void OnAttached(RagonEntity entity)
        {
        }
    }
}
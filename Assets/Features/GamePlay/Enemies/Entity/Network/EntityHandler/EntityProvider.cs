using System;
using GamePlay.Network.Room.Lifecycle.Runtime;
using Ragon.Client;

namespace GamePlay.Enemies.Entity.Network.EntityHandler
{
    public class EntityProvider : IEntityProvider, IPropertyBinder, IEntityEvents
    {
        public EntityProvider(IRoomProvider roomProvider)
        {
            _roomProvider = roomProvider;
        }

        private readonly IRoomProvider _roomProvider;

        private RagonEntity _entity;

        public int Id => _entity.Id;
        public bool IsAttached => _entity.IsAttached;
        public bool IsMine => _entity.HasAuthority;
        public event Action Detached;

        public void SetEntity(RagonEntity entity)
        {
            _entity = entity;
            _entity.Detached += OnDetached;
        }

        public void DestroyEntity()
        {
            _roomProvider.Room.DestroyEntity(_entity);
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

        private void OnDetached()
        {
            _entity.Detached -= OnDetached;
            Detached?.Invoke();
        }
    }
}
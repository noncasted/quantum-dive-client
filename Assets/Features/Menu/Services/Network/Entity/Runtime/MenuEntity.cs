using System;
using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Menu.Services.Network.SceneCollectors.Runtime;
using Ragon.Client;

namespace Menu.Services.Network.Entity.Runtime
{
    public class MenuEntity : IMenuEntity, IScopeSwitchListener
    {
        public MenuEntity(IMenuSceneCollector sceneCollector)
        {
            _sceneCollector = sceneCollector;
        }
        
        private readonly IMenuSceneCollector _sceneCollector;
        private readonly List<RagonProperty> _properties = new();
        
        private RagonEntity _entity;
        
        public event Action Created;

        public void OnEnabled()
        {
            
        }

        public void OnDisabled()
        {
            if (_entity != null)
                _entity.Attached -= OnAttached;
        }
        
        public void ListenEvent<TEvent>(Action<RagonPlayer, TEvent> callback) where TEvent : IRagonEvent, new()
        {
            _entity.OnEvent(callback);    
        }

        public void ReplicateEvent<TEvent>(TEvent data) where TEvent : IRagonEvent, new()
        {
            _entity.ReplicateEvent(data);
        }

        public void CreateEntity()
        {
            if (_entity != null)
                _entity.Attached -= OnAttached;
            
            _entity = new RagonEntity(0, 4);
            
            foreach (var property in _properties)
                _entity.State.AddProperty(property);
            
            _sceneCollector.AddEntity(_entity);

            _entity.Attached += OnAttached;
        }

        public void AddProperty(RagonProperty property)
        {
            _properties.Add(property);
        }

        private void OnAttached(RagonEntity entity)
        {
            Created?.Invoke();
        }
    }
}
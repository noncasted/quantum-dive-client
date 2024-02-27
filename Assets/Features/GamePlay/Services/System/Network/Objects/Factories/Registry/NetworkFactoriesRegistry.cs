﻿using System;
using System.Collections.Generic;
using Common.Architecture.Lifetimes;
using Common.Architecture.Scopes.Runtime.Callbacks;
using Global.Network.Objects.EntityListeners.Runtime;
using Global.Network.Objects.Factories.Abstract;
using Ragon.Client;

namespace GamePlay.System.Network.Objects.Factories.Registry
{
    public class NetworkFactoriesRegistry : INetworkFactoriesRegistry, IScopeSwitchListener
    {
        public NetworkFactoriesRegistry(IEntityListener entityListener)
        {
            _entityListener = entityListener;
        }

        private readonly IEntityListener _entityListener;
        private readonly Dictionary<int, IEntityFactory> _factories = new();

        private ushort _counter;
        
        public void OnEnabled()
        {
            _entityListener.EntityReceived += OnEntityReceived;
        }

        public void OnDisabled()
        {
            _entityListener.EntityReceived -= OnEntityReceived;
        }

        public ushort Register(IEntityFactory factory, ILifetime lifetime)
        {
            _counter++;
            _factories.Add(_counter, factory);
            
            lifetime.ListenTerminate(() => _factories.Remove(factory.Id));
            
            return _counter;
        }
        
        private void OnEntityReceived(EntityPrefabId id, RagonEntity entity)
        {
            var factory = GetFactory(id.FactoryId);
            
            factory.OnRemoteCreated(id.ObjectId, entity).Forget();
        }
        
        private IEntityFactory GetFactory(int id)
        {
            if (_factories.ContainsKey(id) == false)
                throw new NullReferenceException($"No factory with id: {id} found");

            return _factories[id];
        }
    }
}
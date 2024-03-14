using System;
using System.Collections.Generic;
using Global.Network.Handlers.ClientHandler.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Services.Network.Entity.Runtime;
using Ragon.Client;
using UnityEngine;

namespace Menu.Services.Network.PlayersLists.Runtime
{
    public class PlayersListHandler : 
        IPlayersList,
        IScopeAwakeListener,
        IScopeSwitchListener,
        IRagonPlayerLeftListener
    {
        public PlayersListHandler(IMenuEntity entity, IClientProvider clientProvider)
        {
            _entity = entity;
            _clientProvider = clientProvider;
        }

        private readonly IMenuEntity _entity;
        private readonly IClientProvider _clientProvider;
        private readonly PlayersList _list = new();
        
        public event Action<IReadOnlyList<PlayerData>> Changed;

        public void OnAwake()
        {
            _entity.AddProperty(_list);
        }
        
        public void OnEnabled()
        {
            _clientProvider.Client.AddListener(this);

            _list.Updated += OnUpdated;
            _entity.Created += OnEntityCreated;
        }
        
        public void OnDisabled()
        {
            _clientProvider.Client.RemoveListener(this);
            
            _list.Updated -= OnUpdated;
            _entity.Created -= OnEntityCreated;
        }
        
        public void AddPlayer(RagonPlayer player)
        {
            _entity.ReplicateEvent(new AddPlayerEvent());
        }

        public void OnPlayerLeft(RagonClient client, RagonPlayer player)
        {
            Debug.Log($"On player left: {client.Room.Local.IsRoomOwner} {player.Id}");
            
            if (client.Room.Local.IsRoomOwner == false)
                return;
            
            _list.Remove(player.Id);
        }

        private void OnEntityCreated()
        {
            _list.Clear();
            _entity.ListenEvent<AddPlayerEvent>(OnPlayerAdded);
        }
        
        private void OnUpdated(IReadOnlyList<PlayerData> list)
        {
            Changed?.Invoke(list);
        }

        private void OnPlayerAdded(RagonPlayer player, AddPlayerEvent eventData)
        {
            var data = new PlayerData(player.Id, player.Name, player.IsRoomOwner);

            _list.Add(data);
        }
    }
}
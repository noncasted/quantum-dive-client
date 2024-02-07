using System.Collections.Generic;
using GamePlay.Player.Entity.Definition;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Player.Services.List.Runtime
{
    public class PlayerList : IPlayerList, IRagonPlayerLeftListener
    {
        private readonly Dictionary<RagonPlayer, IPlayerEntity> _players = new();

        public void Add(RagonPlayer player, IPlayerEntity root)
        {
            _players.Add(player, root);
        }

        public IPlayerEntity Get(RagonPlayer player)
        {
            if (_players.ContainsKey(player) == false)
            {
                Debug.LogError($"Player: {player.Name} not found in registry");
                return null;
            }
            
            return _players[player];
        }

        public void OnPlayerLeft(RagonClient client, RagonPlayer player)
        {
            if (_players.ContainsKey(player) == false)
            {
                Debug.LogError($"Player: {player.Name} not found in registry");
                return;
            }

            _players.Remove(player);
        }
    }
}
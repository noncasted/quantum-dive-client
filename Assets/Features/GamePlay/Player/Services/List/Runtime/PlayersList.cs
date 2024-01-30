using System.Collections.Generic;
using Features.GamePlay.Player.Entity.Setup.Root.Common;
using Features.GamePlay.Player.Services.List.Definition;
using Ragon.Client;
using UnityEngine;

namespace GamePlay.Network.Players.Registry.Runtime
{
    public class PlayersList : IPlayersList, IRagonPlayerLeftListener
    {
        private readonly Dictionary<RagonPlayer, INetworkPlayer> _players = new();

        public void Add(RagonPlayer player, INetworkPlayer root)
        {
            _players.Add(player, root);
        }

        public INetworkPlayer Get(RagonPlayer player)
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
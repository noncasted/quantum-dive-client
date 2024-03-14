using System.Collections.Generic;
using Menu.Services.Network.PlayersLists.Runtime;
using UnityEngine;
using VContainer;

namespace Menu.Lobby.UI.Runtime.Players
{
    [DisallowMultipleComponent]
    public class PlayersListView : MonoBehaviour
    {
        [Inject]
        private void Construct(IPlayersList players)
        {
            _players = players;
        }

        [SerializeField] private PlayerView _prefab;
        [SerializeField] private Transform _root;

        private readonly List<PlayerView> _allViews = new();

        private IPlayersList _players;

        private void OnEnable()
        {
            _players.Changed += OnPlayersChanged;
        }

        private void OnDisable()
        {
            _players.Changed -= OnPlayersChanged;
        }

        private void OnPlayersChanged(IReadOnlyList<PlayerData> players)
        {
            foreach (var view in _allViews)
                view.Disable();

            AddRequired(players.Count);

            for (var i = 0; i < players.Count; i++)
            {
                var player = players[i];
                var view = _allViews[i];

                view.Enable();
                view.Construct(player);
            }
        }

        private void AddRequired(int required)
        {
            if (_allViews.Count >= required)
                return;
            
            var difference = required - _allViews.Count;

            for (var i = 0; i < difference; i++)
            {
                var view = Instantiate(_prefab, _root);
                _allViews.Add(view);
            }
        }
    }
}
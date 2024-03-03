using System;
using UnityEngine;

namespace Menu.Lobby.UI.Runtime.Status.Timer
{
    [DisallowMultipleComponent]
    public class LobbyTimerView : MonoBehaviour, ILobbyTimerView
    {
        [SerializeField] private GameObject _body;
        
        public void SetTime(float time)
        {
            var timeSpan = TimeSpan.FromSeconds(time);
            var text = timeSpan.ToString("hh':'mm':'ss").Remove(0, 3);
          //  _text.text = text;
        }

        public void Show()
        {
            _body.SetActive(true);
        }

        public void Hide()
        {
            _body.SetActive(false);
        }
    }
}
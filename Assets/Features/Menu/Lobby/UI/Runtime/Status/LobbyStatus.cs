using Global.System.MessageBrokers.Runtime;
using Menu.Lobby.UI.Runtime.Status.Timer;
using UnityEngine;
//using TMPro;

namespace Menu.Lobby.UI.Runtime.Status
{
    [DisallowMultipleComponent]
    public class LobbyStatus : MonoBehaviour, ILobbyStatus
    {
        //[SerializeField] private TMP_Text _idText;
        [SerializeField] private LobbyTimerView _timerView;
        // [SerializeField] private UniversalButton _backButton;
        // [SerializeField] private UniversalButton _playButton;
        // [SerializeField] private UniversalButton _idCopyButton;

        private void OnEnable()
        {
            // _backButton.Clicked += OnBackClicked;
            // _playButton.Clicked += OnPlayClicked;
            // _idCopyButton.Clicked += OnIdCopyClicked;
        }
        
        private void OnDisable()
        {
            // _backButton.Clicked -= OnBackClicked;
            // _playButton.Clicked -= OnPlayClicked;
            // _idCopyButton.Clicked -= OnIdCopyClicked;
        }

        public void ShowPlayButton()
        {
         //   _playButton.Show();
        }

        public void HidePlayButton()
        {
      //      _playButton.Hide();
        }

        public void ShowTimer()
        {
            _timerView.Show();
        }

        public void HideTimer()
        {
            _timerView.Hide();
        }

        public void Construct(string roomId)
        {
          //  _idText.text = roomId;
        }

        private void OnBackClicked()
        {
            Msg.Publish(new LobbyBackRequestEvent());
        }

        private void OnPlayClicked()
        {
            Msg.Publish(new LobbyPlayRequestEvent());
        }
            
        private void OnIdCopyClicked()
        {
        //    GUIUtility.systemCopyBuffer = _idText.text;
        }
    }
}
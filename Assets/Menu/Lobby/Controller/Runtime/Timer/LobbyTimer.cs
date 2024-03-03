using Cysharp.Threading.Tasks;
using Menu.Lobby.UI.Runtime.Status.Timer;
using UnityEngine;

namespace Menu.Lobby.Controller.Runtime.Timer
{
    public class LobbyTimer : ILobbyTimer
    {
        public LobbyTimer(ILobbyTimerView timerView)
        {
            _timerView = timerView;
        }

        private const float _time = 5f;
        private readonly ILobbyTimerView _timerView;

        public async UniTask Delay()
        {
            var time = _time;

            while (time > 0f)
            {
                time -= Time.deltaTime;

                _timerView.SetTime(time);
                await UniTask.Yield();
            }
        }
    }
}
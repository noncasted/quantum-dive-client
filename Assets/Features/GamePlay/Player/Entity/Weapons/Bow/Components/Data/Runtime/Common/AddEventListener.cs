using System;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Services.Upgrades.Events;
using Global.System.MessageBrokers.Runtime;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common
{
    public class AddEventListener<T> : IPlayerSwitchListener where T : IAddEvent
    {
        private IDisposable _listener;
        private Action<int> _target;

        public void OnEnabled()
        {
            _listener = Msg.Listen<T>(OnEventReceived);
        }

        public void OnDisabled()
        {
            _listener?.Dispose();
        }

        public void AddListener(Action<int> listener)
        {
            _target = listener;
        }

        private void OnEventReceived(T data)
        {
            _target?.Invoke(data.Value);
        }
    }
}
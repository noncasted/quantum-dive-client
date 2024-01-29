using System;
using GamePlay.Player.Entity.Setup.EventLoop.Abstract;
using GamePlay.Player.Services.Upgrades.Events;
using Global.System.MessageBrokers.Runtime;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common
{
    public class MultiplierEventListener<T> : IPlayerSwitchListener where T : IMultiplierEvent
    {
        private IDisposable _listener;
        private Action<float> _target;

        public void OnEnabled()
        {
            _listener = Msg.Listen<T>(OnEventReceived);
        }

        public void OnDisabled()
        {
            _listener?.Dispose();
        }

        public void AddListener(Action<float> listener)
        {
            _target = listener;
        }

        private void OnEventReceived(T data)
        {
            _target?.Invoke(data.Value);
        }
    }
}
using System;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.UI.Overlay.Abstract;
using Global.System.MessageBrokers.Abstract;
using Internal.Scopes.Abstract.Instances.Services;

namespace GamePlay.Player.UI.Overlay.Runtime.HealthBars
{
    public class HealthBar : IScopeSwitchListener
    {
        public HealthBar(IHealthBarView view)
        {
            _view = view;
        }

        private readonly IHealthBarView _view;

        private IDisposable _listener;

        public void OnEnabled()
        {
            _listener = Msg.Listen<PlayerHealthChangeEvent>(OnHealthChanged);
        }

        public void OnDisabled()
        {
            _listener.Dispose();
        }

        private void OnHealthChanged(PlayerHealthChangeEvent data)
        {
            _view.SetHealth(data.Current, data.Max);
        }
    }
}
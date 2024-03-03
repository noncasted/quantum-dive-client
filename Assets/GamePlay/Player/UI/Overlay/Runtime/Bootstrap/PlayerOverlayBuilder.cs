using Common.Architecture.Container.Abstract;
using GamePlay.Player.UI.Overlay.Runtime.HealthBars;
using UnityEngine;

namespace GamePlay.Player.UI.Overlay.Runtime.Bootstrap
{
    [DisallowMultipleComponent]
    public class PlayerOverlayBuilder : MonoBehaviour
    {
        [SerializeField] private HealthBarView _healthBar;

        public void Build(IServiceCollection services)
        {
            services.Register<HealthBar>()
                .WithParameter<IHealthBarView>(_healthBar)
                .AsCallbackListener();
        }
    }
}
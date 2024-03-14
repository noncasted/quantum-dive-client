using GamePlay.Player.UI.Overlay.Abstract;
using GamePlay.Player.UI.Overlay.Runtime.HealthBars;
using Internal.Scopes.Abstract.Containers;
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
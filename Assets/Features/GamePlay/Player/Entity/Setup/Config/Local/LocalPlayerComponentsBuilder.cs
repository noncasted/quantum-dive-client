using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Setup.Config.Local
{
    [DisallowMultipleComponent]
    public class LocalPlayerComponentsBuilder : MonoBehaviour, IPlayerContainerBuilder
    {
        [SerializeField] private LocalPlayerComponents _assets;

        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            var assets = _assets.GetAssets();

            foreach (var asset in assets)
                asset.Create(services, callbacks);
        }
    }
}
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Setup.Config.Remote
{
    [DisallowMultipleComponent]
    public class RemoteBowComponentsBuilder : MonoBehaviour, IPlayerContainerBuilder
    {
        [SerializeField] private RemoteBowConfig _assets;

        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            var assets = _assets.GetFactories();

            foreach (var asset in assets)
                asset.Create(services, callbacks);
        }
    }
}
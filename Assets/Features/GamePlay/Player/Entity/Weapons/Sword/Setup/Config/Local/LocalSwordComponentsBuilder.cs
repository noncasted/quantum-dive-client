using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Local
{
    [DisallowMultipleComponent]
    public class LocalSwordComponentsBuilder : MonoBehaviour, IPlayerContainerBuilder
    {
        [SerializeField] private LocalSwordComponents _assets;

        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            var assets = _assets.GetFactories();

            foreach (var asset in assets)
                asset.Create(services, callbacks);
        }
    }
}
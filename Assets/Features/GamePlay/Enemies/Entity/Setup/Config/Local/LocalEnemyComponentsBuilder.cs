using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Config.Local
{
    public class LocalEnemyComponentsBuilder : MonoBehaviour, IEnemyContainerBuilder
    {
        [SerializeField] private LocalEnemyComponents _assets;

        public void OnBuild(IServiceCollection services, ICallbackRegistry callbacks)
        {
            var assets = _assets.GetAssets();

            foreach (var asset in assets)
                asset.Create(services, callbacks);
        }
    }
}
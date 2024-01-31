using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Setup.Abstract;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Setup.Config.Remote
{
    public class RemoteEnemyComponentsBuilder : MonoBehaviour, IEnemyContainerBuilder
    {
        [SerializeField] private RemoteEnemyComponents _config;

        public void OnBuild(IServiceCollection services, ICallbackRegistry callbacks)
        {
            var assets = _config.GetAssets();

            foreach (var asset in assets)
                asset.Create(services, callbacks);
        }
    }
}
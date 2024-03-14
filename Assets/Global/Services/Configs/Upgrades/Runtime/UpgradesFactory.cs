using Cysharp.Threading.Tasks;
using Global.Configs.Upgrades.Abstract;
using Global.Configs.Upgrades.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Configs.Upgrades.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConfigsUpgradesRoutes.ServiceName, menuName = ConfigsUpgradesRoutes.ServicePath)]
    public class UpgradesFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<Upgrades>()
                .As<IUpgrades>()
                .AsCallbackListener();
        }
    }
}
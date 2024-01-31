using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Features.Global.Services.Configs.Upgrades.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.Configs.Upgrades.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ConfigsUpgradesRoutes.ServiceName, menuName = ConfigsUpgradesRoutes.ServicePath)]
    public class UpgradesFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<Upgrades>()
                .As<IUpgrades>()
                .AsCallbackListener();
        }
    }
}
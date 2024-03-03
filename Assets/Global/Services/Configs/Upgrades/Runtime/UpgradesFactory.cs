using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Global.Configs.Upgrades.Abstract;
using Global.Configs.Upgrades.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Configs.Upgrades.Runtime
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
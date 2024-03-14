using Cysharp.Threading.Tasks;
using Global.System.ApplicationProxies.Abstract;
using Global.System.ApplicationProxies.Common;
using Global.System.ApplicationProxies.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ApplicationProxies.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ApplicationProxyRoutes.ServiceName,
        menuName = ApplicationProxyRoutes.ServicePath)]
    public class ApplicationProxyFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private ApplicationProxyLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<ApplicationProxyLogger>()
                .WithParameter(_logSettings);

            services.Register<ApplicationProxy>()
                .As<IScreen>()
                .As<IApplicationFlow>();
        }
    }
}
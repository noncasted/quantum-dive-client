using Cysharp.Threading.Tasks;
using Global.System.ResourcesCleaners.Abstract;
using Global.System.ResourcesCleaners.Common;
using Global.System.ResourcesCleaners.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.ResourcesCleaners.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ResourcesCleanerRouter.ServiceName,
        menuName = ResourcesCleanerRouter.ServicePath)]
    public class ResourcesCleanerFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private ResourcesCleanerLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<ResourcesCleanerLogger>().WithParameter(_logSettings);

            services.Register<ResourcesCleaner>()
                .As<IResourcesCleaner>();
        }
    }
}
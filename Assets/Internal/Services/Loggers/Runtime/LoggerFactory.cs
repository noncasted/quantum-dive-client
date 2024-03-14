using Internal.Abstract;
using Internal.Scopes.Abstract.Options;
using Internal.Services.Loggers.Common;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Internal.Services.Loggers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LoggerRoutes.ServiceName,
        menuName = LoggerRoutes.ServicePath)]
    public class LoggerFactory : ScriptableObject, IInternalServiceFactory
    {
        public void Create(IOptions options, IContainerBuilder services)
        {
            services.Register<Logger>(Lifetime.Singleton)
                .As<IGlobalLogger>();
        }
    }
}
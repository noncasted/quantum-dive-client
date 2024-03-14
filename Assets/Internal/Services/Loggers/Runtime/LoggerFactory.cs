using Internal.Abstract;
using Internal.Loggers.Common;
using Internal.Scopes.Abstract.Options;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Internal.Loggers.Runtime
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
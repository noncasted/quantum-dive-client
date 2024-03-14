using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Global.Cameras.CurrentProvider.Common;
using Global.Cameras.CurrentProvider.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CurrentProvider.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraProviderFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private CurrentCameraLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<CurrentCameraLogger>()
                .WithParameter(_logSettings);

            services.Register<CurrentCameraProvider>()
                .As<ICurrentCameraProvider>()
                .AsCallbackListener();
        }
    }
}
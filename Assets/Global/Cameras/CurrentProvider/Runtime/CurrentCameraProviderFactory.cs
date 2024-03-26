using Cysharp.Threading.Tasks;
using Global.Cameras.CurrentProvider.Abstract;
using Global.Cameras.CurrentProvider.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.CurrentProvider.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CurrentCameraRoutes.ServiceName,
        menuName = CurrentCameraRoutes.ServicePath)]
    public class CurrentCameraProviderFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<CurrentCameraProvider>()
                .As<ICurrentCameraProvider>()
                .AsCallbackListener();
        }
    }
}
using Cysharp.Threading.Tasks;
using Global.Cameras.Utils.Abstract;
using Global.Cameras.Utils.Common;
using Global.Cameras.Utils.Logs;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.Utils.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = CameraUtilsRoutes.ServiceName,
        menuName = CameraUtilsRoutes.ServicePath)]
    public class CameraUtilsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [Indent] private CameraUtilsLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<CameraUtilsLogger>()
                .WithParameter(_logSettings);

            services.Register<CameraUtils>()
                .As<ICameraUtils>()
                .AsCallbackListener();
        }
    }
}
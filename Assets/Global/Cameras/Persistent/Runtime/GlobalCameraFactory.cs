using Cysharp.Threading.Tasks;
using Global.Cameras.Persistent.Abstract;
using Global.Cameras.Persistent.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Cameras.Persistent.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalCameraRoutes.ServiceName,
        menuName = GlobalCameraRoutes.ServicePath)]
    public class GlobalCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private GlobalCamera _prefab;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var globalCamera = Instantiate(_prefab, new Vector3(0f, 0f, -10f), Quaternion.identity);
            globalCamera.name = "Camera_Global";
            globalCamera.gameObject.SetActive(false);

            services.RegisterComponent(globalCamera)
                .As<IGlobalCamera>()
                .AsCallbackListener();

            utils.Binder.MoveToModules(globalCamera);
        }
    }
}
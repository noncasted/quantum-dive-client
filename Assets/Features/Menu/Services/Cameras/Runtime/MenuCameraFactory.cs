using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Menu.Services.Cameras.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Services.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuCameraRoutes.ServiceName, menuName = MenuCameraRoutes.ServicePath)]
    public class MenuCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private Camera _prefab;
        
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var position = new Vector3(0f, 0f, -10f);
            var camera = Instantiate(_prefab, position, Quaternion.identity);
            camera.name = "MenuCamera";

            utils.Binder.MoveToModules(camera.gameObject);
        }
    }
}
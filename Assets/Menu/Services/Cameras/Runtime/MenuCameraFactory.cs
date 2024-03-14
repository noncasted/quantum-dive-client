using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Cysharp.Threading.Tasks;
using Menu.Cameras.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Cameras.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuCameraRoutes.ServiceName, menuName = MenuCameraRoutes.ServicePath)]
    public class MenuCameraFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private Camera _prefab;
        
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var position = new Vector3(0f, 0f, -10f);
            var camera = Instantiate(_prefab, position, Quaternion.identity);
            camera.name = "MenuCamera";

            utils.Binder.MoveToModules(camera.gameObject);
        }
    }
}
using Cysharp.Threading.Tasks;
using GamePlay.Network.Room.Entities.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Room.Entities.Factory
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SceneEntityFactoryRoutes.ServiceName,
        menuName = SceneEntityFactoryRoutes.ServicePath)]
    public class SceneEntityFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<SceneEntityFactory>()
                .As<ISceneEntityFactory>();
        }
    }
}
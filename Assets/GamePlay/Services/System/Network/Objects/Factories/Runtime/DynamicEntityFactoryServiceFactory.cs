using Cysharp.Threading.Tasks;
using GamePlay.Network.Objects.Factories.Common;
using GamePlay.Services.System.Network.Objects.Factories.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Network.Objects.Factories.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NetworkObjectFactoryRoutes.DynamicFactoryName,
        menuName = NetworkObjectFactoryRoutes.DynamicFactoryPath)]
    public class DynamicEntityFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<DynamicEntityFactory>()
                .As<IDynamicEntityFactory>();
        }
    }
}
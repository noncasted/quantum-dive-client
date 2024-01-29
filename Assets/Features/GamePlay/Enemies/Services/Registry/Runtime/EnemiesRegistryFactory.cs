using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Services.Registry.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRegistryRoutes.ServiceName,
        menuName = EnemyRegistryRoutes.ServicePath)]
    public class EnemiesRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemiesRegistry>()
                .As<IEnemiesRegistry>();
        }
    }
}
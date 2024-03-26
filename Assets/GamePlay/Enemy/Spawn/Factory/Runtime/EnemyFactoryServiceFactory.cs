using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Spawn.Factory.Abstract;
using GamePlay.Enemy.Spawn.Factory.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Spawn.Factory.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyFactoryRoutes.ServiceName,
        menuName = EnemyFactoryRoutes.ServicePath)]
    public class EnemyFactoryServiceFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
           services.Register<EnemyFactory>()
                .As<IEnemyFactory>()
                .AsCallbackListener();
        }
    }
}
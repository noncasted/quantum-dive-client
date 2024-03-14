using Cysharp.Threading.Tasks;
using GamePlay.Enemy.List.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.List.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyListRoutes.ServiceName,
        menuName = EnemyListRoutes.ServicePath)]
    public class EnemyListFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<EnemyList>()
                .As<IEnemyList>();
        }
    }
}
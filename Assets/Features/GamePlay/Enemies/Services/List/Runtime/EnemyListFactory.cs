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
    [CreateAssetMenu(fileName = EnemyListRoutes.ServiceName,
        menuName = EnemyListRoutes.ServicePath)]
    public class EnemyListFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyList>()
                .As<IEnemyList>();
        }
    }
}
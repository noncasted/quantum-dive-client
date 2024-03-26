using Common.DataTypes.Runtime.Collections;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.States.Abstract;
using GamePlay.Enemy.Mappers.States.Common;
using GamePlay.Enemy.Services.Mappers.States.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Mappers.States.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyStateMapperRoutes.ServiceName,
        menuName = EnemyStateMapperRoutes.ServicePath)]
    public class EnemyStateMapperFactory : ScriptableRegistry<EnemyStateDefinition>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<EnemyStateMapper>()
                .As<IEnemyStateMapper>()
                .WithParameter(Objects);
        }
    }
}
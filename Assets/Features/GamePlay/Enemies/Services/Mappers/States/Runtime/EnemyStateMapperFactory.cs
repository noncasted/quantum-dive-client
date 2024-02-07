using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.States.Abstract;
using GamePlay.Enemies.Mappers.States.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Mappers.States.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyStateMapperRoutes.ServiceName,
        menuName = EnemyStateMapperRoutes.ServicePath)]
    public class EnemyStateMapperFactory : ScriptableRegistry<EnemyStateDefinition>, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyStateMapper>()
                .As<IEnemyStateMapper>()
                .WithParameter(Objects);
        }
    }
}
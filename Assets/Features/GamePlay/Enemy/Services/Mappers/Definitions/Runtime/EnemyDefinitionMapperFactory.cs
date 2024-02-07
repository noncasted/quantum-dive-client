using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Enemy.Entity.Common.Definition.Asset;
using GamePlay.Enemy.Entity.Common.Definition.Asset.Abstract;
using GamePlay.Enemy.Mappers.Definitions.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Mappers.Definitions.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDefinitionMapperRoutes.ServiceName,
        menuName = EnemyDefinitionMapperRoutes.ServicePath)]
    public class EnemyDefinitionMapperFactory : ScriptableRegistry<EnemyDefinition>, IServiceFactory
    {
        public IReadOnlyList<IEnemyDefinition> Definitions => Objects;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyDefinitionMapper>()
                .As<IEnemyDefinitionMapper>()
                .WithParameter(Definitions);
        }
    }
}
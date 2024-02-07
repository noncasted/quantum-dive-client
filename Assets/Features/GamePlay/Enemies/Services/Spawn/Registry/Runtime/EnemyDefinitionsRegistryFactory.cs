using System.Collections.Generic;
using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using GamePlay.Enemies.Entity.Definition.Asset;
using GamePlay.Enemies.Entity.Definition.Asset.Abstract;
using GamePlay.Enemies.Services.Spawn.Registry.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Services.Spawn.Registry.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyDefinitionsRegistryRoutes.ServiceName,
        menuName = EnemyDefinitionsRegistryRoutes.ServicePath)]
    public class EnemyDefinitionsRegistryFactory : ScriptableRegistry<EnemyDefinition>, IServiceFactory
    {
        public IReadOnlyList<IEnemyDefinition> Definitions => Objects;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            services.Register<EnemyDefinitionsRegistry>()
                .As<IEnemyDefinitionsRegistry>()
                .WithParameter(Definitions);
        }
    }
}
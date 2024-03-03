using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Enemy.Common;
using GamePlay.Enemy.List.Runtime;
using GamePlay.Enemy.Mappers.Definitions.Runtime;
using GamePlay.Enemy.Mappers.States.Runtime;
using GamePlay.Enemy.Spawn.Factory.Runtime;
using GamePlay.Enemy.Spawn.Pool.Runtime;
using GamePlay.Enemy.Updater.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "EnemyServicesCompose",
        menuName = EnemyServicesRoutes.Root + "Compose")]
    public class EnemyServicesCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private EnemyListFactory _list;
        [SerializeField] private EnemyFactoryServiceFactory _factory;
        [SerializeField] private EnemyPoolFactory _pool;
        [SerializeField] private EnemyDefinitionMapperFactory _definitionMapper;
        [SerializeField] private EnemyStateMapperFactory _stateMapper;
        [SerializeField] private EnemyUpdaterFactory _updater;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _list,
            _factory,
            _pool,
            _definitionMapper,
            _stateMapper,
            _updater
        };
    }
}
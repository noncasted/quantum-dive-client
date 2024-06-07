using System.Collections.Generic;
using Common.DataTypes.Runtime.Attributes;
using GamePlay.Common.Routes;
using GamePlay.Enemy.Compose;
using GamePlay.Environment.Bootstrap;
using GamePlay.Player.Services.Compose;
using GamePlay.Services.Common.Compose;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.Network.Compose;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Internal.Scopes.Common.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Common.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayRoutes.Root + "Scene")]
    public class LevelConfig : ScriptableObject, IServiceScopeConfig
    {
        [SerializeField] private GamePlayServicesCompose _services;
        [SerializeField] private LevelEnvironmentFactory _environment;
        [SerializeField] private LevelNetworkCompose _network;
        [SerializeField] private PlayerServicesCompose _player;
        [SerializeField] private EnemyServicesCompose _enemy;
        [SerializeField] private ServiceDefaultCallbacksFactory _serviceDefaultCallbacks;

        [SerializeField] private GamePlayScope _scopePrefab;
        [SerializeField] [CreateSO] private SceneData _servicesScene;
        [SerializeField] private bool _isMock;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public SceneData ServicesScene => _servicesScene;
        public bool IsMock => _isMock;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _environment,
            _serviceDefaultCallbacks
        };

        public IReadOnlyList<IServicesCompose> Composes => new IServicesCompose[]
        {
            _services,
            _network,
            _player,
            _enemy,
        };
    }
}
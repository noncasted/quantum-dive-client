using System.Collections.Generic;
using Common.Architecture.Scopes.Common.DefaultCallbacks;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Common.Compose;
using GamePlay.Common.Routes;
using GamePlay.Common.Scope;
using GamePlay.Enemy.Services.Compose;
using GamePlay.Environment.Bootstrap;
using GamePlay.Player.Services.Compose;
using GamePlay.System.Network.Compose;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Common.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayRoutes.Root + "Scene")]
    public class LevelConfig : ScriptableObject, IScopeConfig
    {
        [SerializeField] private GamePlayServicesCompose _services;
        [SerializeField] private LevelEnvironmentFactory _environment;
        [SerializeField] private LevelNetworkCompose _network;
        [SerializeField] private PlayerServicesCompose _player;
        [SerializeField] private EnemyServicesCompose _enemy;
        [SerializeField] private DefaultCallbacksServiceFactory _defaultCallbacks;

        [SerializeField] private GamePlayScope _scopePrefab;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private bool _isMock;

        public LifetimeScope ScopePrefab => _scopePrefab;
        public ISceneAsset ServicesScene => _servicesScene;
        public bool IsMock => _isMock;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _environment,
            _defaultCallbacks
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
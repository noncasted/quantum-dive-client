﻿using System.Collections.Generic;
using Global.Network.Common;
using Global.Network.Connection.Runtime;
using Global.Network.Handlers.ClientHandler.Runtime;
using Global.Network.Handlers.SceneCollectors.Runtime;
using Global.Network.Objects.EntityListeners.Runtime;
using Global.Network.Session.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "GlobalNetworkCompose", menuName = GlobalNetworkAssetsPaths.Root + "Compose")]
    public class GlobalNetworkCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private ConnectionFactory _connection;
        [SerializeField] private ClientHandlerFactory _client;
        [SerializeField] private SceneCollectorBridgeFactory _sceneCollector;
        [SerializeField] private NetworkEntityListenerFactory _entityListener;
        [SerializeField] private SessionFlowFactory _sessionFlow;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _connection,
            _client,
            _sceneCollector,
            _entityListener,
            _sessionFlow
        };
    }
}
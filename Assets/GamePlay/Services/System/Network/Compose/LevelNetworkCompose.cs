using System.Collections.Generic;
using GamePlay.System.Network.Common;
using GamePlay.System.Network.Messaging.Events.Runtime;
using GamePlay.System.Network.Messaging.REST.Runtime;
using GamePlay.System.Network.Objects.Destroyer.Runtime;
using GamePlay.System.Network.Objects.Factories.Registry;
using GamePlay.System.Network.Objects.Factories.Runtime;
using GamePlay.System.Network.Room.Entities.Factory;
using GamePlay.System.Network.Room.EventLoops.Runtime;
using GamePlay.System.Network.Room.Lifecycle.Runtime;
using GamePlay.System.Network.Room.SceneCollectors.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Network.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "LevelNetworkCompose", menuName = GamePlayNetworkRoutes.Root + "Compose")]
    public class LevelNetworkCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private RoomStarterBaseFactory _roomStarter;
        [SerializeField] private NetworkEntityDestroyerFactory _entityDestroyer;
        [SerializeField] private NetworkFactoriesRegistryFactory _factoriesRegistry;
        [SerializeField] private SceneEntityFactoryServiceFactory _sceneEntityFactory;
        [SerializeField] private NetworkSceneCollectorFactory _sceneCollector;
        [SerializeField] private DynamicEntityFactoryServiceFactory _dynamicEntityFactory;
        [SerializeField] private NetworkEventsLoopFactory _eventsLoop;
        [SerializeField] private MessengerFactory _messenger;
        [SerializeField] private NetworkEventsFactory _events;
        
        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _roomStarter,
            _entityDestroyer,
            _factoriesRegistry,
            _sceneEntityFactory,
            _sceneCollector,
            _dynamicEntityFactory,
            _eventsLoop,
            _messenger,
            _events
        };
    }
}
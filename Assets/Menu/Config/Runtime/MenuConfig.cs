using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using Menu.Lobby.Controller.Runtime;
using Menu.Lobby.UI.Runtime.View;
using Menu.Loop.Runtime;
using Menu.Main.Common;
using Menu.Main.Controller.Runtime;
using Menu.Main.UI.Runtime;
using Menu.Services.Cameras.Runtime;
using Menu.Services.Network.Entity.Runtime;
using Menu.Services.Network.PlayersLists.Runtime;
using Menu.Services.Network.SceneCollectors.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Menu.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "MenuConfig", menuName = MenuAssetsPaths.Root + "Config")]
    public class MenuConfig : ScriptableObject, IServiceScopeConfig
    {
        [FoldoutGroup("Common")] [SerializeField]
        private BaseMenuLoopFactory _menuLoop;

        [FoldoutGroup("Common")] [SerializeField]
        private MenuCameraFactory _camera;

        [FoldoutGroup("Main")] [SerializeField]
        private MenuControllerFactory _menuController;

        [FoldoutGroup("Main")] [SerializeField]
        private BaseMenuUiFactory _menuUI;

        [FoldoutGroup("Lobby")] [SerializeField]
        private LobbyControllerFactory _lobbyController;

        [FoldoutGroup("Lobby")] [SerializeField]
        private BaseLobbyUiFactory _lobbyUI;

        [FoldoutGroup("Network")] [SerializeField]
        private MenuEntityFactory _entity;

        [FoldoutGroup("Network")] [SerializeField]
        private PlayerListFactory _list;

        [FoldoutGroup("Network")] [SerializeField]
        private MenuSceneCollectorFactory _sceneCollector;

        [SerializeField] private MenuScope _scope;
        [SerializeField] private SceneData _servicesScene;
        [SerializeField] private bool _isMock;

        public LifetimeScope ScopePrefab => _scope;
        public SceneData ServicesScene => _servicesScene;
        public bool IsMock => _isMock;

        public IReadOnlyList<IServiceFactory> Services => new IServiceFactory[]
        {
            _menuLoop,
            _camera,
            _menuController,
            _lobbyController,

            _entity,
            _list,
            _sceneCollector,
            _menuUI,
            _lobbyUI
        };

        public IReadOnlyList<IServicesCompose> Composes => new List<IServicesCompose>();
    }
}
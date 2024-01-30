using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using Internal.Services.Scenes.Data;
using Menu.Cameras.Runtime;
using Menu.Lobby.Controller.Runtime;
using Menu.Lobby.UI.Runtime.View;
using Menu.Loop.Runtime;
using Menu.Main.Common;
using Menu.Main.Controller.Runtime;
using Menu.Main.UI.Runtime;
using Menu.Network.Entity.Runtime;
using Menu.Network.PlayersLists.Runtime;
using Menu.Network.SceneCollectors.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace Menu.Config.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "MenuConfig", menuName = MenuAssetsPaths.Root + "Config")]
    public class MenuConfig : ScriptableObject, IScopeConfig
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


        public LifetimeScope ScopePrefab => _scope;
        public ISceneAsset ServicesScene => _servicesScene;

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
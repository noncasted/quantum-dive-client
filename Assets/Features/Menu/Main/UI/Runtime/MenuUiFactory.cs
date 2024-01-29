using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using Internal.Services.Scenes.Data;
using Menu.Main.UI.Common;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuUIRoutes.ServiceName,
        menuName = MenuUIRoutes.ServicePath)]
    public class MenuUiFactory : BaseMenuUiFactory
    {
        [SerializeField] [Scene] private SceneData _scene;

        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var scene = await utils.SceneLoader.LoadTyped<MenuView>(_scene);

            var ui = scene.Searched;

            services.RegisterComponent(ui)
                .As<IMenuView>();
        }
    }
}
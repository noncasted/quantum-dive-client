using Internal.Scopes.Abstract.Containers;

using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
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

        public override async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var (_, ui) = await utils.SceneLoader.LoadTyped<MenuView>(_scene);

            services.RegisterComponent(ui)
                .As<IMenuView>();
        }
    }
}
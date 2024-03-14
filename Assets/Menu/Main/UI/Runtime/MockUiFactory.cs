using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Menu.Main.UI.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Menu.Main.UI.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MenuUIRoutes.MockName,
        menuName = MenuUIRoutes.MockPath)]
    public class MockUiFactory : BaseMenuUiFactory
    {
        public override async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var ui = FindFirstObjectByType<MenuView>();

            services.RegisterComponent(ui)
                .As<IMenuView>();
        }
    }
}
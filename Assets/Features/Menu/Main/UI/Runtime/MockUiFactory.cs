using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
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
        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var ui = FindFirstObjectByType<MenuView>();

            services.RegisterComponent(ui)
                .As<IMenuView>();
        }
    }
}
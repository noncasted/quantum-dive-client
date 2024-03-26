using Cysharp.Threading.Tasks;
using Global.UI.Nova.Common;
using Global.UI.Nova.InputManagers.Abstract;
using Global.UI.Nova.InputManagers.Runtime;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.UI.Nova.Compose
{
    [InlineEditor]
    [CreateAssetMenu(fileName = NovaRoutes.ComposeName, menuName = NovaRoutes.ComposePath)]
    public class NovaCompose : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<NovaUIInputHandler>()
                .As<IUIInputHandler>()
                .AsCallbackListener();
        }
    }
}
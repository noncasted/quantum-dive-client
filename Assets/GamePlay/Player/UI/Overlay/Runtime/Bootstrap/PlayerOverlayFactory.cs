using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;

using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.UI.Overlay.Common;
using Internal.Scopes.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.UI.Overlay.Runtime.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = PlayerOverlayRoutes.ServiceName,
        menuName = PlayerOverlayRoutes.ServicePath)]
    public class PlayerOverlayFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var (_, view) = await utils.SceneLoader.LoadTyped<PlayerOverlayBuilder>(_scene);

            view.Build(services);
        }
    }
}
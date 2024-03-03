using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Player.UI.Overlay.Common;
using Internal.Scenes.Data;
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

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var scene = await utils.SceneLoader.LoadTyped<PlayerOverlayBuilder>(_scene);

            var view = scene.Searched;

            view.Build(services);
        }
    }
}
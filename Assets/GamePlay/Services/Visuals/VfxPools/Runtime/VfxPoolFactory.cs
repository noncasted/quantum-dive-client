using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Common.Tools.ObjectsPools.Runtime;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Visuals.VfxPools.Common;
using Internal.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Visuals.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.ServiceName, menuName = VfxPoolRoutes.ServicePath)]
    public class VfxPoolFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] [Indent] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var loadResult = await utils.SceneLoader.LoadTyped<ObjectsPoolsHandler>(_scene);

            var pool = loadResult.Searched;

            pool.CreatePools(services, loadResult.Scene);

            services.Register<VfxPool>()
                .As<IVfxPool>()
                .WithParameter<IPoolProvider>(pool);
        }
    }
}
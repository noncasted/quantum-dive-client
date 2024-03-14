using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Common.Tools.ObjectsPools.Runtime;
using Common.Tools.ObjectsPools.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Visuals.VfxPools.Common;
using Internal.Scopes.Abstract.Scenes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Visuals.VfxPools.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = VfxPoolRoutes.ServiceName, menuName = VfxPoolRoutes.ServicePath)]
    public class VfxPoolFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField] [Indent] private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var (loadResult, pool) = await utils.SceneLoader.LoadTyped<ObjectsPoolsHandler>(_scene);

            pool.CreatePools(services, loadResult.Scene);

            services.Register<VfxPool>()
                .As<IVfxPool>()
                .WithParameter<IPoolProvider>(pool);
        }
    }
}
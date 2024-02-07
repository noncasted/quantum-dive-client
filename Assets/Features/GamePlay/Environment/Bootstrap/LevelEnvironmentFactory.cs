using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Utils;
using Common.DataTypes.Collections.NestedScriptableObjects.Attributes;
using Cysharp.Threading.Tasks;
using GamePlay.Environment.Common;
using Internal.Services.Scenes.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Environment.Bootstrap
{
    [CreateAssetMenu(fileName = LevelEnvironmentRoutes.ServiceName,
        menuName = LevelEnvironmentRoutes.ServicePath)]
    public class LevelEnvironmentFactory : LevelEnvironmentBaseFactory
    {
        [SerializeField] [NestedScriptableObjectField] [Indent]
        private SceneData _scene;

        public override async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            // var result = await utils.SceneLoader.LoadTyped<SceneBootstrapper>(_scene);
            //
            // SceneManager.SetActiveScene(result.Scene);
            //
            // var bootstrapper = result.Searched;
            //
            // bootstrapper.Build(services, utils.Callbacks);
        }
    }
}
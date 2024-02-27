using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
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
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelEnvironmentRoutes.ServiceName,
        menuName = LevelEnvironmentRoutes.ServicePath)]
    public class LevelEnvironmentFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] [NestedScriptableObjectField]
        private SceneData _scene;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var factory = await GetFactory();
            await factory.Create(services, utils);

            return;

            async UniTask<ILevelSceneServicesFactory> GetFactory()
            {
                if (utils.IsMock == true)
                    return FindFirstObjectByType<LevelSceneServicesFactory>();

                var result = await utils.SceneLoader.LoadTyped<ILevelSceneServicesFactory>(_scene);
                SceneManager.SetActiveScene(result.Scene);
                return result.Searched;
            }
        }
    }
}
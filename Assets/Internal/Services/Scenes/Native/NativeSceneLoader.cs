using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Scenes;
using Internal.Services.Scenes.Logs;

namespace Internal.Services.Scenes.Native
{
    public class NativeSceneLoader : ISceneLoader
    {
        public NativeSceneLoader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        public async UniTask<ISceneLoadResult> Load(SceneData data)
        {
            // var targetScene = new Scene();
            //
            // SceneManager.sceneLoaded += OnSceneLoaded;
            //
            // void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
            // {
            //     if (loadedScene.name != sceneAsset.Name)
            //         return;
            //
            //     targetScene = loadedScene;
            //     SceneManager.sceneLoaded -= OnSceneLoaded;
            // }
            //
            // var handle = SceneManager.LoadSceneAsync(sceneAsset.Name, LoadSceneMode.Additive);
            // var task = handle.ToUniTask();
            // await task;
            //
            // await UniTask.WaitUntil(() => targetScene.name == sceneAsset.Name);
            //
            // _logger.OnSceneLoad(targetScene);
            //
            // var result = new NativeSceneLoadResult(targetScene);
            //
            // return result;

            return null;
        }
    }
}
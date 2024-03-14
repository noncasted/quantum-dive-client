using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Scenes;
using Internal.Services.Scenes.Logs;

namespace Internal.Services.Scenes.Addressable
{
    public class AddressablesSceneLoader : ISceneLoader
    {
        public AddressablesSceneLoader(ScenesFlowLogger logger)
        {
            _logger = logger;
        }

        private readonly ScenesFlowLogger _logger;

        // public async UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset)
        // {
        //     var scene = await Addressables.LoadSceneAsync(sceneAsset.Reference, LoadSceneMode.Additive)
        //         .ToUniTask();
        //
        //     _logger.OnSceneLoad(scene.Scene);
        //
        //     return new AddressablesSceneLoadResult(scene);
        // }

        public async UniTask<ISceneLoadResult> Load(SceneData data)
        {
            return null;
        }
    }
}
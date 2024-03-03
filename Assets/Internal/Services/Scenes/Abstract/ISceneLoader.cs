using Cysharp.Threading.Tasks;
using Internal.Scenes.Data;

namespace Internal.Scenes.Abstract
{
    public interface ISceneLoader
    {
        UniTask<ISceneLoadResult> Load(ISceneAsset sceneAsset);
        UniTask<ISceneLoadTypedResult<T>> LoadTyped<T>(ISceneAsset sceneAsset);
    }
}
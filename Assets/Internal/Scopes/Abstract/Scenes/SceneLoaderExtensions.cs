using System;
using Cysharp.Threading.Tasks;

namespace Internal.Scopes.Abstract.Scenes
{
    public static class SceneLoaderExtensions
    {
        public static async UniTask<(ISceneLoadResult, T)> LoadTyped<T>(this ISceneLoader loader, SceneData data)
        {
            var result = await loader.Load(data);

            var rootObjects = result.Scene.GetRootGameObjects();

            foreach (var rootObject in rootObjects)
            {
                if (rootObject.TryGetComponent(out T searched) == true)
                    return (result, searched);
            }

            throw new NullReferenceException($"Searched {typeof(T)} is not found");
        }
    }
}
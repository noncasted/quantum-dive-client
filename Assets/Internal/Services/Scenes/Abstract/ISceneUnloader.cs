using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Scenes;

namespace Internal.Scenes.Abstract
{
    public interface ISceneUnloader
    {
        UniTask Unload(ISceneLoadResult result);

        UniTask Unload(IReadOnlyList<ISceneLoadResult> results);
    }
}
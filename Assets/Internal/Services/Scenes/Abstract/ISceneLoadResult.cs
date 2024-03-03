using UnityEngine.SceneManagement;

namespace Internal.Scenes.Abstract
{
    public interface ISceneLoadResult
    {
        Scene Scene { get; }
    }
}
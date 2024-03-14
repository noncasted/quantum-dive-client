using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Internal.Scenes.Abstract;
using Internal.Scenes.Native;
using Internal.Scopes.Abstract.Callbacks;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Abstract.Scenes;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Internal.Scopes.Mocks.Runtime
{
    public class MockBootstrapResult
    {
        public MockBootstrapResult(LifetimeScope parent)
        {
            Parent = parent;
            Resolver = parent.Container;
        }
        
        public readonly IObjectResolver Resolver;
        public readonly LifetimeScope Parent;

        public async UniTask RegisterLoadedScene(IServiceScopeLoadResult loadResult)
        {
            var scenes = new List<ISceneLoadResult>(loadResult.Scenes);
            scenes.Add(new NativeSceneLoadResult(SceneManager.GetActiveScene()));
        }
    }
}
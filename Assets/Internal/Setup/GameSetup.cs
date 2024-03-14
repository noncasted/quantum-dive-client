using Cysharp.Threading.Tasks;
using Global.Config.Runtime;
using Internal.Scope;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;
using VContainer;

namespace Internal.Setup
{
    [DisallowMultipleComponent]
    public class GameSetup : MonoBehaviour
    {
        [SerializeField] private InternalScopeConfig _internal;
        [SerializeField] private GlobalScopeConfig _global;
        [SerializeField] private GameObject _loading;

        private void Awake()
        {
            Setup().Forget();
        }

        private async UniTask Setup()
        {
            var internalScopeLoader = new InternalScopeLoader(_internal);
            var internalScope = await internalScopeLoader.Load();
            var scopeLoaderFactory = internalScope.Container.Resolve<IServiceScopeLoader>();
            var scopeLoadResult = await scopeLoaderFactory.Load(internalScope, _global);

            _loading.SetActive(false);
        }
    }
}
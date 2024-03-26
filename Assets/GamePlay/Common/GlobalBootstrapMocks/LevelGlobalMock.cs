using Cysharp.Threading.Tasks;
using GamePlay.Common.Config.Runtime;
using Global.Common.Mocks.Runtime;
using Global.Network.Connection.Abstract;
using Global.Network.Session.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using UnityEngine;
using VContainer;

namespace GamePlay.Common.GlobalBootstrapMocks
{
    [DisallowMultipleComponent]
    public class LevelGlobalMock : MockBase
    {
        [SerializeField] private LevelConfig _levelScope;
        
        public override async UniTaskVoid Process()
        {
            // var result = await _mock.BootstrapGlobal();
            // await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var resolver = result.Resolver;
            
            var connection = resolver.Resolve<IConnection>();
            await connection.Connect("player");
            
            var sessionName = "level-test";
            
            var sessionJoin = resolver.Resolve<ISessionJoin>();
            var joinResult =  await sessionJoin.JoinRandom();
            
            var scopeLoader = resolver.Resolve<IServiceScopeLoader>();
            var scopeResult = await scopeLoader.Load(result.Parent, _levelScope);
            
            await result.RegisterLoadedScene(scopeResult);
            await scopeResult.Callbacks.RunConstruct();
        }
    }
}
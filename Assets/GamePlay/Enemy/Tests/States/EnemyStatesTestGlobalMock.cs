using Cysharp.Threading.Tasks;
using Global.Network.Connection.Abstract;
using Global.Network.Session.Abstract;
using Internal.Scopes.Abstract.Instances.Services;
using Internal.Scopes.Mocks.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Enemy.Tests.States
{
    [DisallowMultipleComponent]
    public class EnemyStatesTestGlobalMock : MockBase
    {
        [SerializeField] private EnemyStatesTestAsset _level;
        [SerializeField] private EnemyStatesTestRunner _testRunner;
        [SerializeField] private GlobalMock _mock;
        
        public override async UniTaskVoid Process()
        {
            var result = await _mock.BootstrapGlobal();
            await BootstrapLocal(result);
        }

        private async UniTask BootstrapLocal(MockBootstrapResult result)
        {
            var resolver = result.Resolver;
            
            var connection = resolver.Resolve<IConnection>();
            await connection.Connect("player");
            
            var sessionName = "level-test";
            
            var sessionJoin = resolver.Resolve<ISessionJoin>();
            var joinResult =  await sessionJoin.JoinRandom();
            
            var scopeLoaderFactory = resolver.Resolve<IServiceScopeLoader>();
            var scope = await scopeLoaderFactory.Load(result.Parent, _level);
            scope.Scope.Container.Inject(_testRunner);


            await result.RegisterLoadedScene(scope);
        }
    }
}
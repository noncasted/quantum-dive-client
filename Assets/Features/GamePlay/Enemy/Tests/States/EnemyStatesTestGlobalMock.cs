using Common.Architecture.Mocks.Runtime;
using Common.Architecture.Scopes.Factory;
using Cysharp.Threading.Tasks;
using Global.Network.Connection.Runtime;
using Global.Network.Session.Runtime.Join;
using UnityEngine;
using VContainer;

namespace GamePlay.Enemies.Tests.States
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
            
            var scopeLoaderFactory = resolver.Resolve<IScopeLoaderFactory>();
            var scopeLoader = scopeLoaderFactory.Create(_level, result.Parent);
            var scope = await scopeLoader.Load();
            scope.Scope.Container.Inject(_testRunner);


            await result.RegisterLoadedScene(scope);
        }
    }
}
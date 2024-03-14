using Cysharp.Threading.Tasks;
using Global.GameLoops.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.GameLoops.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GameLoopRouter.MockName,
        menuName = GameLoopRouter.MockPath)]
    public class GameLoopMock : GameLoopFactory
    {
        public override async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            
        }
    }
}
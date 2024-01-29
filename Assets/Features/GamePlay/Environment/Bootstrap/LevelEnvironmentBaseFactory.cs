using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.Environment.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Environment.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = LevelEnvironmentRoutes.ServiceName,
        menuName = LevelEnvironmentRoutes.ServicePath)]
    public abstract class LevelEnvironmentBaseFactory : ScriptableObject, IServiceFactory
    {
        public abstract UniTask Create(IServiceCollection services, IScopeUtils utils);
    }
}
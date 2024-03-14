using Common.Tools.UniversalAnimators.Old.Updaters.Common;
using Cysharp.Threading.Tasks;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Common.Tools.UniversalAnimators.Old.Updaters.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AnimatorsUpdaterRoutes.ServiceName, menuName = AnimatorsUpdaterRoutes.ServicePath)]
    public class AnimatorsUpdaterFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<AnimatorsUpdater>()
                .As<IAnimatorsUpdater>()
                .AsCallbackListener();
        }
    }
}
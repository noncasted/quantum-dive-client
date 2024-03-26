using Cysharp.Threading.Tasks;
using Global.System.Updaters.Abstract;
using Global.System.Updaters.Common;
using Global.System.Updaters.Delays;
using Global.System.Updaters.Runtime;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.Updaters.Setup
{
    [InlineEditor]
    [CreateAssetMenu(fileName = UpdaterRouter.ServiceName,
        menuName = UpdaterRouter.ServicePath)]
    public class UpdaterFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private Updater _prefab;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var updater = Instantiate(_prefab);
            updater.name = "Updater";

            services.RegisterComponent(updater)
                .As<IUpdater>()
                .As<IUpdateSpeedModifier>()
                .As<IUpdateSpeedSetter>()
                .AsSelfResolvable()
                .AsCallbackListener();

            services.Register<DelayRunner>()
                .As<IDelayRunner>();

            utils.Binder.MoveToModules(updater);
        }
    }
}
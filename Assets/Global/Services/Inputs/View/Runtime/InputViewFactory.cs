using Common.DataTypes.Collections.ScriptableRegistries;
using Cysharp.Threading.Tasks;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Common;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Actions;
using Global.Inputs.View.Runtime.Sources;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputViewRoutes.ServiceName,
        menuName = InputViewRoutes.ServicePath)]
    public class InputViewFactory : ScriptableRegistry<InputSourceFactory>, IServiceFactory
    {
        [SerializeField] private InputViewLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var controls = new Controls();

            foreach (var sourceFactory in Objects)
                sourceFactory.Create(controls, services);
            
            services.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            services.Register<InputView>()
                .WithParameter(controls)
                .AsImplementedInterfaces()
                .AsCallbackListener();

            services.Register<InputActions>()
                .As<IInputActions>()
                .AsSelf()
                .AsSelfResolvable();

            services.Register<InputSourcesHandler>()
                .As<IInputSourcesHandler>();
        }
    }
}
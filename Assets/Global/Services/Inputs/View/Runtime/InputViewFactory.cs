using Cysharp.Threading.Tasks;
using Global.Inputs.View.Abstract;
using Global.Inputs.View.Common;
using Global.Inputs.View.Implementations.Combat.Abstract;
using Global.Inputs.View.Implementations.Combat.Runtime;
using Global.Inputs.View.Implementations.Mouses.Abstract;
using Global.Inputs.View.Implementations.Mouses.Runtime;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Global.Inputs.View.Implementations.Movement.Runtime;
using Global.Inputs.View.Logs;
using Global.Inputs.View.Runtime.Actions;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Inputs.View.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = InputViewRoutes.ServiceName,
        menuName = InputViewRoutes.ServicePath)]
    public class InputViewFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private InputViewLogSettings _logSettings;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            var controls = new Controls();

            services.RegisterInstance(controls);
            services.RegisterInstance(controls.GamePlay);
            services.RegisterInstance(controls.Debug);
            services.RegisterInstance(controls.AssemblyGraph);

            services.Register<MovementInputView>()
                .As<IMovementInputView>()
                .AsCallbackListener();

            services.Register<RollInputView>()
                .As<IRollInputView>()
                .AsCallbackListener();

            services.Register<MouseInput>()
                .As<IMouseInput>()
                .AsCallbackListener();

            services.Register<CombatInput>()
                .As<ICombatInput>()
                .AsCallbackListener();

            var callbacks = new InputCallbacks();
            utils.Callbacks.AddCustomListener(callbacks);

            services.Register<InputViewLogger>()
                .WithParameter(_logSettings);

            services.Register<InputView>()
                .WithParameter(controls)
                .WithParameter(callbacks)
                .AsImplementedInterfaces()
                .AsCallbackListener();

            services.Register<InputActions>()
                .As<IInputActions>()
                .AsCallbackListener();
        }
    }
}
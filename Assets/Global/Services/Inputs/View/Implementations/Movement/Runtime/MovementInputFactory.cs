using Global.Inputs.View.Abstract;
using Global.Inputs.View.Common;
using Global.Inputs.View.Implementations.Movement.Abstract;
using Internal.Scopes.Abstract.Containers;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Movement.Runtime
{
    [CreateAssetMenu(
        fileName = InputViewRoutes.InputSourcePrefix + "Movement",
        menuName = InputViewRoutes.InputSourcesRoot + "Movement")]
    public class MovementInputFactory : InputSourceFactory
    {
        public override void Create(Controls controls, IServiceCollection services)
        {
            var gamePlay = controls.GamePlay;
            
            services.Register<MovementInputView>()
                .WithParameter(gamePlay)
                .As<IMovementInputView>()
                .AsSelfResolvable();
            
            services.Register<RollInputView>()
                .WithParameter(gamePlay)
                .As<IRollInputView>()
                .AsSelfResolvable();
        }
    }
}
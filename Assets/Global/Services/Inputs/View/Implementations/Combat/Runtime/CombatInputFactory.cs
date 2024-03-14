using Global.Inputs.View.Abstract;
using Global.Inputs.View.Common;
using Global.Inputs.View.Implementations.Combat.Abstract;
using Internal.Scopes.Abstract.Containers;
using UnityEngine;

namespace Global.Inputs.View.Implementations.Combat.Runtime
{
    [CreateAssetMenu(
        fileName = InputViewRoutes.InputSourcePrefix + "Combat",
        menuName = InputViewRoutes.InputSourcesRoot + "Combat")]
    public class CombatInputFactory : InputSourceFactory
    {
        public override void Create(Controls controls, IServiceCollection services)
        {
            var gamePlay = controls.GamePlay;

            services.Register<CombatInput>()
                .WithParameter(gamePlay)
                .As<ICombatInput>()
                .AsSelfResolvable();
        }
    }
}
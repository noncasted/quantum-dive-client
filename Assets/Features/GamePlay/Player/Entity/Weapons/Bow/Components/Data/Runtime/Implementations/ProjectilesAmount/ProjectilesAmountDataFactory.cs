using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Services.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ProjectilesAmount
{
    [CreateAssetMenu(fileName = DataRoutes.ProjectilesAmountName,
        menuName = DataRoutes.ProjectilesAmountPath)]
    public class ProjectilesAmountDataFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var addListener = new AddEventListener<ProjectilesAmountAddEvent>();
            var multiplierListener = new MultiplierEventListener<ProjectilesAmountMultiplierEvent>();

            callbacks.Listen(addListener);
            callbacks.Listen(multiplierListener);

            services.Register<ProjectilesAmountData>()
                .As<IProjectilesAmountData>()
                .WithParameter(addListener)
                .WithParameter(multiplierListener);
        }
    }
}
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Services.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ShotDelays
{
    [CreateAssetMenu(fileName = DataRoutes.ShotDelayName,
        menuName = DataRoutes.ShotDelayPath)]
    public class ShotDelayDataFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var multiplierListener = new MultiplierEventListener<ShotDelayMultiplierEvent>();

            callbacks.Listen(multiplierListener);

            services.Register<ShotDelayData>()
                .As<IShotDelayData>()
                .WithParameter(multiplierListener);
        }
    }
}
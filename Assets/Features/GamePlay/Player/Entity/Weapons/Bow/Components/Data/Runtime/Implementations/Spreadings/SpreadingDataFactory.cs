using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Services.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.Spreadings
{
    [CreateAssetMenu(fileName = DataRoutes.SpreadingName,
        menuName = DataRoutes.SpreadingPath)]
    public class SpreadingDataFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            var multiplierListener = new MultiplierEventListener<SpreadingMultiplierEvent>();

            callbacks.Listen(multiplierListener);

            services.Register<SpreadingData>()
                .As<ISpreadingData>()
                .WithParameter(multiplierListener);
        }
    }
}
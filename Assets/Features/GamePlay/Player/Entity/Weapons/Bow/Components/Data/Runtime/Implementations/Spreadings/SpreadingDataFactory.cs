using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.Spreadings
{
    [CreateAssetMenu(fileName = DataRoutes.SpreadingName,
        menuName = DataRoutes.SpreadingPath)]
    public class SpreadingDataFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var multiplierListener = new MultiplierEventListener<SpreadingMultiplierEvent>();

            utils.CallbacksRegistry.Listen(multiplierListener);

            services.Register<SpreadingData>()
                .As<ISpreadingData>()
                .WithParameter(multiplierListener);
        }
    }
}
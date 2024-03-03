using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.InputName, menuName = BowStrafeRoutes.InputPath)]
    public class StrafeInputFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<StrafeInputReceiver>()
                .As<IStrafeInputReceiver>()
                .AsCallbackListener();
        }
    }
}
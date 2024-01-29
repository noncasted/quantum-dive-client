using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.States.Strafes.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.States.Strafes.InputReceiver
{
    [InlineEditor]
    [CreateAssetMenu(fileName = BowStrafeRoutes.InputName, menuName = BowStrafeRoutes.InputPath)]
    public class StrafeInputFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<StrafeInputReceiver>()
                .As<IStrafeInputReceiver>()
                .AsCallbackListener();
        }
    }
}
using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Common;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime
{
    [CreateAssetMenu(fileName = InputReceiverRoutes.ComponentName,
        menuName = InputReceiverRoutes.ComponentPath)]
    public class InputReceiverFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<BowShootInputReceiver>()
                .AsCallbackListener()
                .As<IBowShootInputReceiver>()
                .AsSelf()
                .AsSelfResolvable();
        }
    }
}
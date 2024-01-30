using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Common;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime
{
    [CreateAssetMenu(fileName = InputReceiverRoutes.ComponentName,
        menuName = InputReceiverRoutes.ComponentPath)]
    public class InputReceiverFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<BowShootInputReceiver>()
                .AsCallbackListener()
                .As<IBowShootInputReceiver>()
                .AsSelf()
                .AsSelfResolvable();
        }
    }
}
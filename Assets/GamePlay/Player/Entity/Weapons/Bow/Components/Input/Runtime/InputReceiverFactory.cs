using GamePlay.Player.Entity.Weapons.Bow.Components.Input.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Input.Runtime
{
    [CreateAssetMenu(fileName = InputReceiverRoutes.ComponentName,
        menuName = InputReceiverRoutes.ComponentPath)]
    public class InputReceiverFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<BowShootInputReceiver>()
                .AsCallbackListener()
                .As<IBowShootInputReceiver>()
                .AsSelf()
                .AsSelfResolvable();
        }
    }
}
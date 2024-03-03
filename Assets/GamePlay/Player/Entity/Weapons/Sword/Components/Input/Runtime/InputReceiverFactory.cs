using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordInputRoutes.ComponentName, menuName = SwordInputRoutes.ComponentPath)]
    public class InputReceiverFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<InputReceiver>()
                .As<IInputReceiver>()
                .AsCallbackListener();
        }
    }
}
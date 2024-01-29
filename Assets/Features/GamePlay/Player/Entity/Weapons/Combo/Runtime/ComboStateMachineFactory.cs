using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Combo.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Combo.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ComboStateMachineRoutes.ComponentName,
        menuName = ComboStateMachineRoutes.ComponentPath)]
    public class ComboStateMachineFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<ComboStateMachine>()
                .As<IComboStateMachine>();
        }
    }
}
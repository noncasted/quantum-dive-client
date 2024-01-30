using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
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
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<ComboStateMachine>()
                .As<IComboStateMachine>();
        }
    }
}
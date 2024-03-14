using GamePlay.Player.Entity.Components.Combo.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Combo.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = ComboStateMachineRoutes.ComponentName,
        menuName = ComboStateMachineRoutes.ComponentPath)]
    public class ComboStateMachineFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<ComboStateMachine>()
                .As<IComboStateMachine>();
        }
    }
}
using GamePlay.Enemy.Entity.Components.StateSelectors;
using GamePlay.Enemy.Entity.Types.Melee.States.StateSelector.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MeleeStateSelectorRoutes.ComponentName,
        menuName = MeleeStateSelectorRoutes.ComponentPath)]
    public class MeleeStateSelectorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<MeleeStateSelector>()
                .As<IStateSelector>();
        }
    }
}
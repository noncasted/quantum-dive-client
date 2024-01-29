using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Melee.States.StateSelector.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MeleeStateSelectorRoutes.ComponentName,
        menuName = MeleeStateSelectorRoutes.ComponentPath)]
    public class MeleeStateSelectorFactory : ScriptableObject, IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<MeleeStateSelector>()
                .As<IStateSelector>();
        }
    }
}
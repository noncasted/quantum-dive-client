using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Range.States.StateSelector.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Range.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RangeStateSelectorRoutes.ComponentName,
        menuName = RangeStateSelectorRoutes.ComponentPath)]
    public class RangeStateSelectorFactory : ScriptableObject, IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<RangeStateSelector>()
                .As<IStateSelector>();
        }
    }
}
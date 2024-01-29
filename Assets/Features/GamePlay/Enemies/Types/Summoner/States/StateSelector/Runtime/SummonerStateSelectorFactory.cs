using Common.Architecture.Container.Abstract;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Setup.Abstract;
using GamePlay.Enemies.Types.Summoner.States.StateSelector.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Summoner.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SummonerStateSelectorRoutes.ComponentName,
        menuName = SummonerStateSelectorRoutes.ComponentPath)]
    public class SummonerStateSelectorFactory : ScriptableObject, IEnemyComponentFactory
    {
        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<SummonerStateSelector>()
                .As<IStateSelector>();
        }
    }
}
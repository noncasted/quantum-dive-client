using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Types.Summoner.States.StateSelector.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Summoner.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SummonerStateSelectorRoutes.ComponentName,
        menuName = SummonerStateSelectorRoutes.ComponentPath)]
    public class SummonerStateSelectorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<SummonerStateSelector>()
                .As<IStateSelector>();
        }
    }
}
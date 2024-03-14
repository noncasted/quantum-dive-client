using GamePlay.Enemy.Entity.Components.StateSelectors;
using GamePlay.Enemy.Entity.Types.Summoner.States.StateSelector.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Summoner.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SummonerStateSelectorRoutes.ComponentName,
        menuName = SummonerStateSelectorRoutes.ComponentPath)]
    public class SummonerStateSelectorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IScopedEntityUtils utils)
        {
            services.Register<SummonerStateSelector>()
                .As<IStateSelector>();
        }
    }
}
﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Components.StateSelectors;
using GamePlay.Enemy.Entity.Types.Range.States.StateSelector.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = RangeStateSelectorRoutes.ComponentName,
        menuName = RangeStateSelectorRoutes.ComponentPath)]
    public class RangeStateSelectorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<RangeStateSelector>()
                .As<IStateSelector>();
        }
    }
}
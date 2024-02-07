﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.StateSelectors;
using GamePlay.Enemies.Entity.Types.Melee.States.StateSelector.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Melee.States.StateSelector.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MeleeStateSelectorRoutes.ComponentName,
        menuName = MeleeStateSelectorRoutes.ComponentPath)]
    public class MeleeStateSelectorFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<MeleeStateSelector>()
                .As<IStateSelector>();
        }
    }
}
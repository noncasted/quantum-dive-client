﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Services.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ProjectilesAmount
{
    [CreateAssetMenu(fileName = DataRoutes.ProjectilesAmountName,
        menuName = DataRoutes.ProjectilesAmountPath)]
    public class ProjectilesAmountDataFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var addListener = new AddEventListener<ProjectilesAmountAddEvent>();
            var multiplierListener = new MultiplierEventListener<ProjectilesAmountMultiplierEvent>();

            utils.Callbacks.Listen(addListener);
            utils.Callbacks.Listen(multiplierListener);

            services.Register<ProjectilesAmountData>()
                .As<IProjectilesAmountData>()
                .WithParameter(addListener)
                .WithParameter(multiplierListener);
        }
    }
}
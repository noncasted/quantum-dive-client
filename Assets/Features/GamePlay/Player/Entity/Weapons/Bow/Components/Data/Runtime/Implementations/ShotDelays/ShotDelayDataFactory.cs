﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using Cysharp.Threading.Tasks;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Common;
using GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Common;
using GamePlay.Player.Services.Upgrades.Events;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Components.Data.Runtime.Implementations.ShotDelays
{
    [CreateAssetMenu(fileName = DataRoutes.ShotDelayName,
        menuName = DataRoutes.ShotDelayPath)]
    public class ShotDelayDataFactory : ScriptableObject, IComponentFactory
    {
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            var multiplierListener = new MultiplierEventListener<ShotDelayMultiplierEvent>();

            utils.Callbacks.Listen(multiplierListener);

            services.Register<ShotDelayData>()
                .As<IShotDelayData>()
                .WithParameter(multiplierListener);
        }
    }
}
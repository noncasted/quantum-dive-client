﻿using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.States.SubStates.Damaged.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.States.SubStates.Damaged.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = DamagedRoutes.LocalName,
        menuName = DamagedRoutes.LocalPath)]
    public class LocalDamagedFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private DamagedConfig _config;

        public void Create(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.Register<LocalDamaged>()
                .WithParameter<IDamagedConfig>(_config)
                .As<IDamaged>()
                .AsCallbackListener();
        }
    }
}
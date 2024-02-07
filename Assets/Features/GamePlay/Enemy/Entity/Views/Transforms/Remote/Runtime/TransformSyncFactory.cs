﻿using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Common;
using GamePlay.Enemy.Entity.Views.Transforms.Remote.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Remote.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = TransformSyncRoutes.ServiceName,
        menuName = TransformSyncRoutes.ServicePath)]
    public class TransformSyncFactory : ScriptableObject, IComponentFactory
    {
        [SerializeField] private TransformSyncLogSettings _logSettings;

        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.Register<TransformSyncLogger>()
                .WithParameter(_logSettings);

            services.Register<TransformSync>()
                .AsCallbackListener();
        }
    }
}
﻿using Cysharp.Threading.Tasks;
using GamePlay.Services.Combat.Hitboxes.Abstract;
using GamePlay.Services.Hitboxes.Common;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Hitboxes.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = HitboxRegistryRoutes.ServiceName,
        menuName = HitboxRegistryRoutes.ServicePath)]
    public class HitboxRegistryFactory : ScriptableObject, IServiceFactory
    {
        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
        {
            services.Register<HitboxRegistry>()
                .As<IHitboxRegistry>();
        }
    }
}
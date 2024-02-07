using Common.Architecture.Container.Abstract;
using Common.Architecture.Scopes.Runtime.Services;
using Common.Architecture.Scopes.Runtime.Utils;
using Cysharp.Threading.Tasks;
using GamePlay.System.Ecs.Common;
using GamePlay.System.Ecs.Runtime.Abstract;
using GamePlay.System.Ecs.Runtime.Entities;
using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.System.Ecs.Runtime.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EcsRoutes.ServiceName,
        menuName = EcsRoutes.ServicePath)]
    public class EcsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EcsHandler _prefab;

        public async UniTask Create(IServiceCollection services, IScopeUtils utils)
        {
            var world = new EcsWorld();

            services.Register<EcsHandler>()
                .WithParameter(world)
                .As<IEcsWorldProvider>()
                .AsCallbackListener();

            services.Register<EntityCreator>()
                .WithParameter(world)
                .As<IEntityCreator>();

            services.Register<EntityDestroyer>()
                .WithParameter(world)
                .As<IEntityDestroyer>();

            services.Register<EntityComponentSetter>()
                .WithParameter(world)
                .As<IEntityComponentSetter>();
        }
    }
}
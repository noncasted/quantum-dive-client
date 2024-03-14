using Cysharp.Threading.Tasks;
using GamePlay.Ecs.Common;
using GamePlay.Ecs.Runtime.Entities;
using GamePlay.Services.System.Ecs.Abstract;
using Internal.Scopes.Abstract.Containers;
using Internal.Scopes.Abstract.Instances.Services;
using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Ecs.Runtime.Bootstrap
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EcsRoutes.ServiceName,
        menuName = EcsRoutes.ServicePath)]
    public class EcsFactory : ScriptableObject, IServiceFactory
    {
        [SerializeField] private EcsHandler _prefab;

        public async UniTask Create(IServiceCollection services, IServiceScopeUtils utils)
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
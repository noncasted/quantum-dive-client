using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Cameras.Runtime;
using GamePlay.Common.Routes;
using GamePlay.Ecs.Runtime.Bootstrap;
using GamePlay.Hitboxes.Runtime;
using GamePlay.Loop.Runtime;
using GamePlay.Projectiles.Bootstrap;
using GamePlay.Targets.Registry.Runtime;
using GamePlay.VfxPools.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "GamePlayServicesCompose",
        menuName = GamePlayServicesRoutes.Root + "Compose")]
    public class GamePlayServicesCompose : ScriptableObject, IServicesCompose
    {
        [SerializeField] private ProjectilesServiceFactory _projectiles;
        [SerializeField] private LevelLoopFactory _levelLoop;
        [SerializeField] private HitboxRegistryFactory _hitboxRegistry;
        [SerializeField] private TargetRegistryFactory _targetRegistry;
        [SerializeField] private LevelCameraFactory _levelCamera;
        [SerializeField] private VfxPoolFactory _vfxPool;
        [SerializeField] private EcsFactory _ecs;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _projectiles,
            _levelLoop,
            _hitboxRegistry,
            _targetRegistry,
            _levelCamera,
            _vfxPool,
            _ecs
        };
    }
}
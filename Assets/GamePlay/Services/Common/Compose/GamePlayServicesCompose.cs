using System.Collections.Generic;
using Common.Architecture.Scopes.Runtime.Services;
using GamePlay.Combat.Hitboxes.Runtime;
using GamePlay.Combat.Projectiles.Bootstrap;
using GamePlay.Combat.Targets.Registry.Runtime;
using GamePlay.Common.Routes;
using GamePlay.Loop.Runtime;
using GamePlay.System.Ecs.Runtime.Bootstrap;
using GamePlay.Visuals.Cameras.Runtime;
using GamePlay.Visuals.VfxPools.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Common.Compose
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
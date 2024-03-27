using System.Collections.Generic;
using GamePlay.Loop.Runtime;
using GamePlay.Services.Cameras.Runtime;
using GamePlay.Services.Common.Routes;
using GamePlay.Services.Ecs.Runtime.Bootstrap;
using GamePlay.Services.Hitboxes.Runtime;
using GamePlay.Services.Projectiles.Bootstrap;
using GamePlay.Services.Targets.Registry.Runtime;
using Internal.Scopes.Abstract.Instances.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Services.Common.Compose
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
        [SerializeField] private EcsFactory _ecs;

        public IReadOnlyList<IServiceFactory> Factories => new IServiceFactory[]
        {
            _projectiles,
            _levelLoop,
            _hitboxRegistry,
            _targetRegistry,
            _levelCamera,
            _ecs
        };
    }
}
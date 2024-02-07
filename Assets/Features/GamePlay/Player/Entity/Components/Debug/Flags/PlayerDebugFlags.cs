using Common.Architecture.Container.Abstract;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Network.TransformSync.Logs;
using GamePlay.Player.Entity.Components.Rotations.Remote.Logs;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Player.Entity.Views.Transforms.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Debug.Flags
{
    [DisallowMultipleComponent]
    public class PlayerDebugFlags : MonoBehaviour, IComponentFactory
    {
        [SerializeField] private TransformDebugFlag _transform;
        [SerializeField] private TransformSyncDebugFlag _transformSync;
        [SerializeField] private RotationSyncDebugFlag _rotationSync;
        [SerializeField] private RemoteStateMachineDebugFlag _stateMachineSync;
        
        public void Create(IServiceCollection services, IEntityUtils utils)
        {
            services.RegisterInstance(_transformSync);
            services.RegisterInstance(_transform);
            services.RegisterInstance(_rotationSync);
            services.RegisterInstance(_stateMachineSync);
        }
    }
}
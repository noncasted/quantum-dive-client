using Common.Architecture.Container.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Logs;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Logs;
using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Local.Runtime;
using GamePlay.Player.Entity.Views.Transforms.Remote.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Debug.Flags
{
    [DisallowMultipleComponent]
    public class PlayerDebugFlags : MonoBehaviour, IPlayerContainerBuilder
    {
        [SerializeField] private TransformDebugFlag _transform;
        [SerializeField] private TransformSyncDebugFlag _transformSync;
        [SerializeField] private RotationSyncDebugFlag _rotationSync;
        [SerializeField] private RemoteStateMachineDebugFlag _stateMachineSync;
        
        public void OnBuild(IServiceCollection services, ICallbackRegister callbacks)
        {
            services.RegisterInstance(_transformSync);
            services.RegisterInstance(_transform);
            services.RegisterInstance(_rotationSync);
            services.RegisterInstance(_stateMachineSync);
        }
    }
}
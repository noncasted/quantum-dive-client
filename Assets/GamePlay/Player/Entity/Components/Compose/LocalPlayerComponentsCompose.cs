using System.Collections.Generic;
using GamePlay.Player.Entity.Components.CameraFollow.Runtime;
using GamePlay.Player.Entity.Components.Combo.Runtime;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Components.Root.Local;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalPlayer_ComponentsCompose",
        menuName = PlayerComponentsRoutes.Root + "Compose/Local")]
    public class LocalPlayerComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private EntityDefaultCallbacksFactory _defaultCallbacks;
        [SerializeField] private DamageProcessorFactory _damageProcessor;
        [SerializeField] private ComboStateMachineFactory _comboStateMachine;
        [SerializeField] private HealthFactory _health;
        [SerializeField] private LocalRotationFactory _rotation;
        [SerializeField] private LocalStateMachineFactory _stateMachine;
        [SerializeField] private LocalPlayerRootFactory _root;
        [SerializeField] private FollowTargetFactory _followTarget;

        [SerializeField] private RemoteStateMachineFactory _remoteStateMachine;
        [SerializeField] private RemoteRotationFactory _remoteRotation;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _defaultCallbacks,
            _damageProcessor,
            _comboStateMachine,
            _health,
            _rotation,
            _stateMachine,
            _root,
            _followTarget,
            
            _remoteStateMachine,
            _remoteRotation
        };
    }
}
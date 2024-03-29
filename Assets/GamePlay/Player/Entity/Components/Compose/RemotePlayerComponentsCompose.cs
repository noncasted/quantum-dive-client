﻿using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Player.Entity.Components.Root.Remote;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using Internal.Scopes.Abstract.Instances.Entities;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemotePlayer_ComponentsCompose", 
        menuName = PlayerComponentsRoutes.Root + "Compose/Remote")]
    public class RemotePlayerComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private DamageProcessorFactory _damageProcessor;
        [SerializeField] private RemoteRotationFactory _remoteRotation;
        [SerializeField] private RemoteStateMachineFactory _stateMachine;
        [SerializeField] private RemotePlayerRootFactory _root;
        [SerializeField] private EntityDefaultCallbacksFactory _defaultCallbacks;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _damageProcessor,
            _remoteRotation,
            _stateMachine,
            _root,
            _defaultCallbacks
        };
    }
}
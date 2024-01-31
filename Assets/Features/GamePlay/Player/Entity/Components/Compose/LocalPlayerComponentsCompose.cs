using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.Combo.Runtime;
using GamePlay.Player.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Player.Entity.Components.Healths.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Local.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.Sorting.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Local.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Features.GamePlay.Player.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "LocalPlayer_ComponentsCompose", 
        menuName = PlayerComponentsRoutes.Root + "Compose/Local")]
    public class LocalPlayerComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private DamageProcessorFactory _damageProcessor;
        [SerializeField] private ComboStateMachineFactory _comboStateMachine;
        [SerializeField] private HealthFactory _health;
        [SerializeField] private LocalRotationFactory _rotation;
        [SerializeField] private SpriteSortingFactory _spriteSorting;
        [SerializeField] private LocalStateMachineFactory _stateMachine;
        
        [SerializeField] private RemoteStateMachineFactory _remoteStateMachine;
        [SerializeField] private RemoteRotationFactory _remoteRotation;
        
        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _damageProcessor,
            _comboStateMachine,
            _health,
            _rotation,
            _spriteSorting,
            _stateMachine
        };
    }
}
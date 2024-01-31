using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Components.Common;
using GamePlay.Player.Entity.Components.DamageProcessors.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Remote.Runtime;
using GamePlay.Player.Entity.Components.Sorting.Runtime;
using GamePlay.Player.Entity.Components.StateMachines.Remote.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Features.GamePlay.Player.Entity.Components.Compose
{
    [InlineEditor]
    [CreateAssetMenu(
        fileName = "RemotePlayer_ComponentsCompose", 
        menuName = PlayerComponentsRoutes.Root + "Compose/Remote")]
    public class RemotePlayerComponentsCompose : ScriptableObject, IComponentsCompose
    {
        [SerializeField] private DamageProcessorFactory _damageProcessor;
        [SerializeField] private RemoteRotationFactory _remoteRotation;
        [SerializeField] private SpriteSortingFactory _spriteSorting;
        [SerializeField] private RemoteStateMachineFactory _stateMachine;

        public IReadOnlyList<IComponentFactory> Factories => new IComponentFactory[]
        {
            _damageProcessor,
            _remoteRotation,
            _spriteSorting,
            _stateMachine
        };
    }
}
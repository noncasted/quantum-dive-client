using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Enemies.Entity.Components.Compose;
using Features.GamePlay.Enemies.Entity.Network.Compose;
using Features.GamePlay.Enemies.Entity.States.Compose;
using GamePlay.Enemies.Entity.Definition.Config;
using GamePlay.Enemies.Types.Melee.States.Attack.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyMeleeConfigRoutes.RemoteName,
        menuName = EnemyMeleeConfigRoutes.RemotePath)]
    public class RemoteEnemyMeleeConfig : ScriptableObject, IRemoteEnemyConfig
    {
        [SerializeField] private RemoteEnemyComponentsCompose _components;
        [SerializeField] private RemoteEnemyStatesCompose _states;
        [SerializeField] private EnemyNetworkCompose _network;

        [SerializeField] private RemoteMeleeAttackFactory _meleeAttack;
        
        [SerializeField] private RemoteEnemyMeleeViewFactory _prefab;
        
        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _meleeAttack
        };

        public IReadOnlyList<IComponentsCompose> Composes => new IComponentsCompose[]
        {
            _components,
            _states,
            _network
        };
    }
}
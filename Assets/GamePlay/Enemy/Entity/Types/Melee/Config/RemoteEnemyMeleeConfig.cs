using System.Collections.Generic;
using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Enemy.Entity.Common.Definition.Config;
using GamePlay.Enemy.Entity.Components.Compose;
using GamePlay.Enemy.Entity.Components.Network.Compose;
using GamePlay.Enemy.Entity.States.Compose;
using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Remote;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.Config
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
        
        public EnemyViewFactory Prefab => _prefab;

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
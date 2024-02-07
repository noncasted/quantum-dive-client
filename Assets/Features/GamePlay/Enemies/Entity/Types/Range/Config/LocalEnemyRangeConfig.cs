﻿using System.Collections.Generic;
using Common.Architecture.Entities.Runtime;
using GamePlay.Enemies.Entity.Components.Compose;
using GamePlay.Enemies.Entity.Definition.Config;
using GamePlay.Enemies.Entity.Network.Compose;
using GamePlay.Enemies.Entity.States.Compose;
using GamePlay.Enemies.Entity.Types.Range.States.Shoot.Local;
using GamePlay.Enemies.Entity.Types.Range.States.StateSelector.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Range.Config
{
    [InlineEditor]
    [CreateAssetMenu(fileName = EnemyRangeConfigRoutes.LocalName,
        menuName = EnemyRangeConfigRoutes.LocalPath)]
    public class LocalEnemyRangeConfig : ScriptableObject, ILocalEnemyConfig
    {
        [SerializeField] private LocalEnemyComponentsCompose _components;
        [SerializeField] private LocalEnemyStatesCompose _states;
        [SerializeField] private EnemyNetworkCompose _network;

        [SerializeField] private LocalShootFactory _shoot;
        [SerializeField] private RangeStateSelectorFactory _stateSelector;
        
        [SerializeField] private LocalEnemyRangeViewFactory _prefab;

        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _shoot,
            _stateSelector
        };

        public IReadOnlyList<IComponentsCompose> Composes => new IComponentsCompose[]
        {
            _components,
            _states,
            _network
        };
    }
}
using System;
using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Local;
using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.Root.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Definition.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Definition.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordConfigRoutes.LocalName,
        menuName = SwordConfigRoutes.LocalPath)]
    public class LocalSwordConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private DefaultCallbacksComponentFactory _defaultCallbacks;
        [SerializeField] private SwordRootFactory _root;
        
        [SerializeField] [Indent] private SwordAttackFactory _attack;
        [SerializeField] [Indent] private InputReceiverFactory _input;
        [SerializeField] [Indent] private TargetsSearcherFactory _targetsSearcher;

        [SerializeField] private LocalSwordViewFactoryFactory _prefab;

        public ScopedEntityViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            _attack,
            _input,
            _targetsSearcher
        };
        
        public IReadOnlyList<IComponentsCompose> Composes => Array.Empty<IComponentsCompose>();
    }
}
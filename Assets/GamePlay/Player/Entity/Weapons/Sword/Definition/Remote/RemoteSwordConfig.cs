using System;
using System.Collections.Generic;

using Internal.Scopes.Abstract.Instances.Entities;
using GamePlay.Player.Entity.Components.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Remote;
using GamePlay.Player.Entity.Weapons.Sword.Components.Root.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Definition.Common;
using Internal.Scopes.Common.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Definition.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordConfigRoutes.RemoteName,
        menuName = SwordConfigRoutes.RemotePath)]
    public class RemoteSwordConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private EntityDefaultCallbacksFactory _defaultCallbacks;
        [SerializeField] private SwordRootFactory _root;

        [SerializeField] [Indent] private RemoteAttackFactory _attack;

        [SerializeField] private RemoteSwordViewFactoryFactory _prefab;

        public EquipmentViewFactory Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            _attack
        };
        
        public IReadOnlyList<IComponentsCompose> Composes => Array.Empty<IComponentsCompose>();
    }
}
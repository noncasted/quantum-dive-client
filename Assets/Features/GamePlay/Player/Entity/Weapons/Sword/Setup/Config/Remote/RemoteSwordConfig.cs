using System.Collections.Generic;
using Common.Architecture.Entities.Common.DefaultCallbacks;
using Common.Architecture.Entities.Runtime;
using Features.GamePlay.Player.Entity.Equipment.Definition;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Remote;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Common;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Root.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordConfigRoutes.RemoteName,
        menuName = SwordConfigRoutes.RemotePath)]
    public class RemoteSwordConfig : ScriptableObject, IEquipmentInstanceConfig
    {
        [SerializeField] private DefaultCallbacksComponentFactory _defaultCallbacks;
        [SerializeField] private SwordRootFactory _root;

        [SerializeField] [Indent] private RemoteAttackFactory _attack;

        [SerializeField] private RemoteSwordViewFactory _prefab;

        public EntitySetupView Prefab => _prefab;

        public IReadOnlyList<IComponentFactory> Components => new IComponentFactory[]
        {
            _defaultCallbacks,
            _root,
            _attack
        };
    }
}
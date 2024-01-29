using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Local;
using GamePlay.Player.Entity.Weapons.Sword.Components.Input.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Components.TargetsSearch.Runtime;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordConfigRoutes.LocalName,
        menuName = SwordConfigRoutes.LocalPath)]
    public class LocalSwordComponents : ScriptableObject
    {
        [SerializeField] [Indent] private SwordAttackFactory _attack;
        [SerializeField] [Indent] private InputReceiverFactory _input;
        [SerializeField] [Indent] private TargetsSearcherFactory _targetsSearcher;
        
        public IComponentFactory[] GetFactories()
        {
            return new IComponentFactory[]
            {
                _attack,
                _input,
                _targetsSearcher
            };
        }
    }
}
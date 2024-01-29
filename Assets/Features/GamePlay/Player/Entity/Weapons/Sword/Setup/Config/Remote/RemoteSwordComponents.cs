using GamePlay.Player.Entity.Setup.Abstract;
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Remote;
using GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Setup.Config.Remote
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordConfigRoutes.RemoteName,
        menuName = SwordConfigRoutes.RemotePath)]
    public class RemoteSwordComponents : ScriptableObject
    {
        [SerializeField] [Indent] private RemoteAttackFactory _attack;
        
        public IComponentFactory[] GetFactories()
        {
            return new IComponentFactory[]
            {
                _attack,
            };
        }
    }
}
using GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Sword.Components.Attacks.Local
{
    [InlineEditor]
    [CreateAssetMenu(fileName = SwordAttackRoutes.ConfigName,
        menuName = SwordAttackRoutes.ConfigPath)]
    public class SwordAttackConfig : ScriptableObject, ISwordAttackConfig
    {
        [SerializeField] [Min(0)] private int _damage;
        [SerializeField] [Min(0f)] private float _pushForce;

        public int Damage => _damage;
        public float PushForce => _pushForce;
    }
}
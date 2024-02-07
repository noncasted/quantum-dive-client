using GamePlay.Enemy.Entity.Types.Melee.States.Attack.Damages;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Melee.Views
{
    [DisallowMultipleComponent]
    public class EnemyMeleeViews : MonoBehaviour
    {
        [SerializeField] private MeleeDamageDealerFactory _damageDealer;
    }
}
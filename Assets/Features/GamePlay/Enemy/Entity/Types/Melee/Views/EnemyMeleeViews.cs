using GamePlay.Enemies.Entity.Types.Melee.States.Attack.Damages;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Melee.Views
{
    [DisallowMultipleComponent]
    public class EnemyMeleeViews : MonoBehaviour
    {
        [SerializeField] private MeleeDamageDealerFactory _damageDealer;
    }
}
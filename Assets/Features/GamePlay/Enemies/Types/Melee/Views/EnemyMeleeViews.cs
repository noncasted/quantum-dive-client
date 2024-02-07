using GamePlay.Enemies.Types.Melee.States.Attack.Damages;
using UnityEngine;

namespace GamePlay.Enemies.Types.Melee.Views
{
    [DisallowMultipleComponent]
    public class EnemyMeleeViews : MonoBehaviour
    {
        [SerializeField] private MeleeDamageDealerFactory _damageDealer;
    }
}
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    [DisallowMultipleComponent]
    public class BowPivotsProvider : MonoBehaviour
    {
        [SerializeField] private BowPivotsView _right;
        [SerializeField] private BowPivotsView _left;

        public BowPivotsView Right => _right;
        public BowPivotsView Left => _left;
    }
}
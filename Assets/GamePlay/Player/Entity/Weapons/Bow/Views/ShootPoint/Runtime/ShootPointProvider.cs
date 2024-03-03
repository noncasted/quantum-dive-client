using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [DisallowMultipleComponent]
    public class ShootPointProvider : MonoBehaviour
    {
        [SerializeField] private Transform _point;

        public Transform Point => _point;
    }
}
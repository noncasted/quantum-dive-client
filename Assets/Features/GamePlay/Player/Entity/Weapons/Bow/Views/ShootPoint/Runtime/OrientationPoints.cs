using System;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [Serializable]
    public class OrientationPoints
    {
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;

        public Transform Left => _left;
        public Transform Right => _right;
    }
}
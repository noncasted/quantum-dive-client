using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [DisallowMultipleComponent]
    public class ShootPointProvider : MonoBehaviour
    {
        [SerializeField] private ShootPointsDictionary _points;

        public IReadOnlyDictionary<PlayerOrientation, OrientationPoints> Points => _points;
    }
}
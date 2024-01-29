using System;
using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    public class BowShootPoint : IBowShootPoint
    {
        public BowShootPoint(ShootPointProvider shootPoints)
        {
            _shootPoints = shootPoints;
        }

        private readonly ShootPointProvider _shootPoints;

        public Vector2 GetShootPoint(PlayerOrientation orientation, Horizontal side)
        {
            var points = _shootPoints.Points[orientation];

            return side switch
            {
                Horizontal.Right => points.Right.position,
                Horizontal.Left => points.Left.position,
                _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
            };
        }
    }
}
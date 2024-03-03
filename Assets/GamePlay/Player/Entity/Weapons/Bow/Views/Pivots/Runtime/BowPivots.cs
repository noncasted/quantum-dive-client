using System;
using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    public class BowPivots : IBowPivotsProvider
    {
        public BowPivots(BowPivotsProvider provider)
        {
            _left = provider.Left;
            _right = provider.Right;
        }
        
        private readonly BowPivotsView _left;
        private readonly BowPivotsView _right;

        public Vector2 GetPosition(Horizontal side, PlayerOrientation orientation)
        {
            return side switch
            {
                Horizontal.Right => _right.Pivots[orientation].position,
                Horizontal.Left => _left.Pivots[orientation].position,
                _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
            };
        }
    }
}
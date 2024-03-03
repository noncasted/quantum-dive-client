using System;
using System.Collections.Generic;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    [Serializable]
    public class BowPivotsView
    {
        [SerializeField] private BowPivotsDictionary _pivots;

        public IReadOnlyDictionary<PlayerOrientation, Transform> Pivots => _pivots;
    }
}
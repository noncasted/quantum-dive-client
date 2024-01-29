using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    [Serializable]
    public class BowPivotsDictionary : ReadOnlyDictionary<PlayerOrientation, Transform>
    {
    }
}
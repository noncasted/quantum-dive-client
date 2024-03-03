using System;
using Common.DataTypes.Collections.ReadOnlyDictionaries.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    [Serializable]
    public class ShootPointsDictionary : ReadOnlyDictionary<PlayerOrientation, OrientationPoints>
    {
        
    }
}
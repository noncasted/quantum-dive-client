using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.ShootPoint.Runtime
{
    public interface IBowShootPoint
    {
        Vector2 GetShootPoint(PlayerOrientation orientation, Horizontal side);
    }   
}
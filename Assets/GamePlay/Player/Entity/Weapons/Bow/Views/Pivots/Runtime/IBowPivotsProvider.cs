using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Pivots.Runtime
{
    public interface IBowPivotsProvider
    {
        Vector2 GetPosition(Horizontal side, PlayerOrientation orientation);
    }
}
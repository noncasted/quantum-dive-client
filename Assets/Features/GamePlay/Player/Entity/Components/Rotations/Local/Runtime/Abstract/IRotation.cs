using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.Components.Rotations.Local.Runtime.Abstract
{
    public interface IRotation
    {
        float Angle { get; }
        Horizontal Side { get; }
        PlayerOrientation Orientation { get; }
    }
}
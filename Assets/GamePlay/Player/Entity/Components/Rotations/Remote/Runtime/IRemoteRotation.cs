using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Runtime
{
    public interface IRemoteRotation
    {
        float Angle { get; }
        Horizontal Side { get; }
        PlayerOrientation Orientation { get; }
    }
}
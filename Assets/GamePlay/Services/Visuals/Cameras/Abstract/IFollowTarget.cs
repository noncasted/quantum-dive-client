using UnityEngine;

namespace GamePlay.Cameras.Abstract
{
    public interface IFollowTarget
    {
        Vector3 Position { get; }
        float Distance { get; }
        float YAngle { get; }
        float XAngle { get; }
        float MoveSpeed { get; }
        float RotationSpeed { get; }
    }
}
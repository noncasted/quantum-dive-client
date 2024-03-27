using UnityEngine;

namespace GamePlay.Services.Cameras.Abstract
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
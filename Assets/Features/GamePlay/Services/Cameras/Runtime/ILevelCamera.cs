using UnityEngine;

namespace GamePlay.Cameras.Runtime
{
    public interface ILevelCamera
    {
        Camera Camera { get; }

        void StartFollow(Transform target);
        void StopFollow();
        void Teleport(Vector2 target);
        void SetSize(float size);
    }
}
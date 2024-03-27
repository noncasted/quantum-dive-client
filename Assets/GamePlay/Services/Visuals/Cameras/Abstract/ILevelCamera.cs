using UnityEngine;

namespace GamePlay.Services.Cameras.Abstract
{
    public interface ILevelCamera
    {
        Camera Camera { get; }

        void StartFollow(IFollowTarget target);
        void StopFollow();
        void Teleport(Vector2 target);
        void SetSize(float size);
    }
}
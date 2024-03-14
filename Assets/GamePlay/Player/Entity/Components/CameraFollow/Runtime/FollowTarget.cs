using GamePlay.Player.Entity.Components.CameraFollow.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Components.CameraFollow.Runtime
{
    public class FollowTarget : IPlayerCameraFollowTarget
    {
        public FollowTarget(IPlayerTransform transform, FollowTargetConfig config)
        {
            _transform = transform;
            _config = config;
        }

        private readonly IPlayerTransform _transform;
        private readonly FollowTargetConfig _config;

        public Vector3 Position => _transform.Position;
        public float Distance => _config.Distance;
        public float YAngle => _config.YAngle;
        public float XAngle => _config.XAngle;
        public float MoveSpeed => _config.MoveSpeed;
        public float RotationSpeed => _config.RotationSpeed;
    }
}
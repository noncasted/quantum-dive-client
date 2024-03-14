using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using GamePlay.Player.Entity.Views.Transforms.Logs;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Runtime
{
    public class PlayerTransform :
        IPlayerTransform,
        IPlayerPosition
    {
        public PlayerTransform(Transform transform, TransformLogger logger, TransformDebugFlag debugFlag)
        {
            Transform = transform;
            _logger = logger;
            _debugFlag = debugFlag;
        }

        private readonly TransformLogger _logger;
        private readonly TransformDebugFlag _debugFlag;

        public Vector3 Position
        {
            get
            {
                var position = Transform.position;
                
                if (_debugFlag.IsActive == true)
                    _logger.OnPositionUsed(position);
                
                return position;
            }
        }

        public Transform Transform { get; }

        public float Rotation => Transform.rotation.eulerAngles.z;
        public Horizontal Look => AngleUtils.ToHorizontal(Rotation);

        public void SetPosition(Vector3 position)
        {
            Transform.position = position;

            if (_debugFlag.IsActive == true)
                _logger.OnPositionSet(position);
        }

        public void SetRotation(float angle)
        {
            Transform.localRotation = Quaternion.Euler(0f, 0f, angle);

            if (_debugFlag.IsActive == true)
                _logger.OnRotationSet(angle);
        }
    }
}
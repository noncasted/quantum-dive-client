using Common.DataTypes.Structs;
using GamePlay.Enemies.Entity.Views.Transforms.Local.Logs;
using UnityEngine;

namespace GamePlay.Enemies.Entity.Views.Transforms.Local.Runtime
{
    public class EnemyTransform :
        IEnemyTransform,
        IEnemyPosition,
        IEnemyTransformProvider
    {
        public EnemyTransform(
            Transform transform,
            TransformLogger logger)
        {
            Transform = transform;
            _logger = logger;
        }

        private readonly TransformLogger _logger;

        public Vector2 Position
        {
            get
            {
                var position = (Vector2)Transform.position;

                _logger.OnPositionUsed(position);

                return position;
            }
        }

        public Transform Transform { get; }

        public float Rotation => Transform.rotation.eulerAngles.z;
        public Horizontal Look => AngleUtils.ToHorizontal(Rotation);

        public void SetPosition(Vector2 position)
        {
            Transform.position = position;

            _logger.OnPositionSet(position);
        }

        public void SetRotation(float angle)
        {
            Transform.localRotation = Quaternion.Euler(0f, 0f, angle);

            _logger.OnRotationSet(angle);
        }
    }
}
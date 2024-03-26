using Common.DataTypes.Runtime.Structs;
using GamePlay.Enemy.Entity.Views.Transforms.Local.Abstract;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.Transforms.Local.Runtime
{
    public class EnemyTransform :
        IEnemyTransform,
        IEnemyPosition,
        IEnemyTransformProvider
    {
        public EnemyTransform(Transform transform)
        {
            Transform = transform;
        }

        public Vector3 Position
        {
            get
            {
                var position = (Vector2)Transform.position;

                return position;
            }
        }

        public Transform Transform { get; }

        public float Rotation => Transform.rotation.eulerAngles.z;
        public Horizontal Look => AngleUtils.ToHorizontal(Rotation);

        public void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }

        public void SetRotation(float angle)
        {
            Transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
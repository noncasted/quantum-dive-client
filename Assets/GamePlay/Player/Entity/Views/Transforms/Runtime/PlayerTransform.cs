using Common.DataTypes.Runtime.Structs;
using GamePlay.Player.Entity.Views.Transforms.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.Transforms.Runtime
{
    public class PlayerTransform :
        IPlayerTransform,
        IPlayerPosition
    {
        public PlayerTransform(Transform transform, TransformDebugFlag debugFlag)
        {
            Transform = transform;
            _debugFlag = debugFlag;
        }

        private readonly TransformDebugFlag _debugFlag;

        public Vector3 Position
        {
            get
            {
                var position = Transform.position;
                
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
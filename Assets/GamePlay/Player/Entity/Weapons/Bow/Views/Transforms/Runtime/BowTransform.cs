using GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Weapons.Bow.Views.Transforms.Runtime
{
    public class BowTransform : IBowTransform
    {
        public BowTransform(Transform transform)
        {
            _transform = transform;
        }
        
        private readonly Transform _transform;

        public Transform Transform => _transform;

        public void SetPosition(Vector2 position)
        {
            _transform.position = position;
        }

        public void SetRotation(float angle)
        {
            _transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
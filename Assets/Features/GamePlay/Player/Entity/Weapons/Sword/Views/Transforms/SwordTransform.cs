using UnityEngine;

namespace Features.GamePlay.Player.Entity.Weapons.Sword.Views.Transforms
{
    public class SwordTransform : ISwordTransform
    {
        public SwordTransform(Transform transform)
        {
            _transform = transform;
        }
        
        private readonly Transform _transform;

        public Transform Transform => _transform;
    }
}
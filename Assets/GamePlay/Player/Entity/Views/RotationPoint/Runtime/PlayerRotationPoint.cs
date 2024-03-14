using GamePlay.Player.Entity.Views.RotationPoint.Abstract;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RotationPoint.Runtime
{
    public class PlayerRotationPoint : IPlayerRotationPoint
    {
        public PlayerRotationPoint(Transform transform)
        {
            _transform = transform;
        }
        
        private readonly Transform _transform;

        public Vector3 Position => _transform.position;
    }
}
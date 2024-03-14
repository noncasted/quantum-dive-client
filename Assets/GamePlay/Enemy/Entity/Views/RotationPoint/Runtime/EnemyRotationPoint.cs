using GamePlay.Enemy.Entity.Views.RotationPoint.Abstract;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Views.RotationPoint.Runtime
{
    public class EnemyRotationPoint : IEnemyRotationPoint
    {
        public EnemyRotationPoint(Transform transform)
        {
            _transform = transform;
        }

        private readonly Transform _transform;

        public Vector2 Position => _transform.position;
    }
}
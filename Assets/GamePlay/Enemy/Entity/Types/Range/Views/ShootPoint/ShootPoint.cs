using UnityEngine;

namespace GamePlay.Enemy.Entity.Types.Range.Views.ShootPoint
{
    public class ShootPoint : IShootPoint
    {
        public ShootPoint(Transform point)
        {
            _point = point;
        }
        
        private readonly Transform _point;

        public Vector3 Point => _point.position;
    }
}
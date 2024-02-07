using UnityEngine;

namespace GamePlay.Enemies.Entity.Types.Range.Views.ShootPoint
{
    public class ShootPoint : IShootPoint
    {
        public ShootPoint(Transform point)
        {
            _point = point;
        }
        
        private readonly Transform _point;

        public Vector2 Point => _point.position;
    }
}
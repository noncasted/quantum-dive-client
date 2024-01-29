using Global.Debugs.Drawing.Runtime;
using UnityEngine;

namespace GamePlay.Player.Entity.Views.RigidBodies.Debug.Gizmos
{
    public class RigidBodyGizmosDrawer : IRigidBodyGizmosDrawer
    {
        public RigidBodyGizmosDrawer(
            IShapeDrawer shapeDrawer,
            IGizmosConfig gizmosConfig)
        {
            _shapeDrawer = shapeDrawer;
            _gizmosConfig = gizmosConfig;
        }

        private readonly IShapeDrawer _shapeDrawer;
        private readonly IGizmosConfig _gizmosConfig;

        public void DrawCast(Vector2 origin, Vector2 direction, float distance, float radius)
        {
            _shapeDrawer.DrawCircle(
                0.1f,
                origin,
                radius,
                _gizmosConfig.Width,
                _gizmosConfig.Color);
        }

        public void DrawHit(Vector2 origin, Vector2 normal)
        {
            var convertedNormal = new Vector2(normal.y, normal.x);
            var start = origin + convertedNormal * 0.2f;
            var end = origin + convertedNormal * -0.2f;

            _shapeDrawer.DrawLine(0.1f, start, end, _gizmosConfig.Width, _gizmosConfig.Color);
        }
    }
}
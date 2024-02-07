using Global.Debugs.Drawing.Runtime;
using UnityEngine;

namespace GamePlay.Enemy.Entity.Components.TargetSearchers.Debug.Gizmos
{
    public class SearchGizmos : ISearchGizmos
    {
        public SearchGizmos(
            IShapeDrawer shapeDrawer,
            ISearchGizmosConfig config)
        {
            _shapeDrawer = shapeDrawer;
            _config = config;
        }
        
        private readonly IShapeDrawer _shapeDrawer;
        private readonly ISearchGizmosConfig _config;

        public void DrawSuccessArea(Vector2 origin, float radius)
        {
            if (_config.IsEnabled == false)
                return;
            
            _shapeDrawer.DrawCircle(
                _config.Duration,
                origin,
                radius,
                _config.AreaWidth,
                _config.FailAreaColor);
            }

        public void DrawFailArea(Vector2 origin, float radius)
        {
            if (_config.IsEnabled == false)
                return;
            
        _shapeDrawer.DrawCircle(
            _config.Duration,
            origin,
            radius,
            _config.AreaWidth,
            _config.FailAreaColor);
         }

        public void DrawSuccessLine(Vector2 origin, Vector2 target)
        {
            if (_config.IsEnabled == false)
                return;
            
            _shapeDrawer.DrawLine(
                _config.Duration,
                origin,
                target,
                _config.TargetLineWidth,
                _config.TargetLineColor);
        }
    }
}
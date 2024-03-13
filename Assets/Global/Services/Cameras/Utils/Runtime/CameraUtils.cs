using Global.Cameras.CurrentProvider.Runtime;
using Global.Cameras.Utils.Logs;
using Global.Debugs.Drawing.Runtime;
using UnityEngine;

namespace Global.Cameras.Utils.Runtime
{
    public class CameraUtils : ICameraUtils
    {
        public CameraUtils(
            IShapeDrawer shapeDrawer,
            ICurrentCameraProvider currentCameraProvider,
            CameraUtilsLogger logger)
        {
            _shapeDrawer = shapeDrawer;
            _currentCameraProvider = currentCameraProvider;
            _logger = logger;
        }

        private readonly IShapeDrawer _shapeDrawer;
        private readonly ICurrentCameraProvider _currentCameraProvider;
        private readonly CameraUtilsLogger _logger;

        public Vector3 ScreenToWorld(Vector3 screen)
        {
            if (_currentCameraProvider.Current == null)
            {
                _logger.OnNoCameraError();
                return Vector3.zero;
            }

            var ray = _currentCameraProvider.Current.ScreenPointToRay(screen);
            Physics.Raycast(ray, out var info, float.PositiveInfinity, LayerMask.GetMask("Collision", "Default"));
            var world = info.point;
            _shapeDrawer.DrawCircle(world, 0.2f);
            _logger.OnScreenToWorld(screen, world);

            return world;
        }
    }
}
using Internal.Services.Loggers.Runtime;
using UnityEngine;

namespace Global.Cameras.Utils.Logs
{
    public class CameraUtilsLogger
    {
        public CameraUtilsLogger(IGlobalLogger logger, CameraUtilsLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly CameraUtilsLogSettings _settings;

        public void OnScreenToWorld(Vector2 screen, Vector2 world)
        {
            if (_settings.IsAvailable(CameraUtilsLogType.ScreenToWorld) == false)
                return;

            _logger.Log($"Screen: {screen}, to world: {world}", _settings.LogParameters);
        }

        public void OnNoCameraError()
        {
            if (_settings.IsAvailable(CameraUtilsLogType.NoCameraError) == false)
                return;

            _logger.Error("No camera assigned", _settings.LogParameters);
        }
    }
}
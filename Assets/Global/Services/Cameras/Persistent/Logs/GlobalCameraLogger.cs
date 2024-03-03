﻿using Internal.Loggers.Runtime;

namespace Global.Cameras.Persistent.Logs
{
    public class GlobalCameraLogger
    {
        public GlobalCameraLogger(IGlobalLogger logger, GlobalCameraLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly GlobalCameraLogSettings _settings;

        public void OnEnabled()
        {
            if (_settings.IsAvailable(GlobalCameraLogType.Enable) == false)
                return;

            _logger.Log("Enabled", _settings.LogParameters);
        }

        public void OnDisabled()
        {
            if (_settings.IsAvailable(GlobalCameraLogType.Disable) == false)
                return;

            _logger.Log("Disabled", _settings.LogParameters);
        }
    }
}
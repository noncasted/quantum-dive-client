using Internal.Loggers.Runtime;
using UnityEngine;

namespace GamePlay.Player.Factory.Factory.Logs
{
    public class PlayerFactoryLogger
    {
        public PlayerFactoryLogger(IGlobalLogger logger, PlayerFactoryLogSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        private readonly IGlobalLogger _logger;
        private readonly PlayerFactoryLogSettings _settings;

        public void OnLocalInstantiated(Vector2 position)
        {
            if (_settings.IsAvailable(PlayerFactoryLogType.LocalInstantiated) == false)
                return;

            _logger.Log($"Local player instantiated at: {position}", _settings.LogParameters);
        }
        
        public void OnRemoteInstantiated(Vector2 position)
        {
            if (_settings.IsAvailable(PlayerFactoryLogType.RemoteInstantiated) == false)
                return;

            _logger.Log($"Remote player instantiated at: {position}", _settings.LogParameters);
        }
    }
}